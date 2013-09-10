﻿using App1.Data;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// 分割ページのアイテム テンプレートについては、http://go.microsoft.com/fwlink/?LinkId=234234 を参照してください

namespace App1
{
    /// <summary>
    /// グループのタイトル、グループ内のアイテムの一覧、および現在選択されているアイテムの
    /// 詳細を表示するページです。
    /// </summary>
    public sealed partial class SplitPage : App1.Common.LayoutAwarePage
    {
        public SplitPage()
        {
            this.InitializeComponent();
        }

        #region ページ状態の管理

        /// <summary>
        /// このページには、移動中に渡されるコンテンツを設定します。前のセッションからページを
        /// 再作成する場合は、保存状態も指定されます。
        /// </summary>
        /// <param name="navigationParameter">このページが最初に要求されたときに
        /// <see cref="Frame.Navigate(Type, Object)"/> に渡されたパラメーター値。
        /// </param>
        /// <param name="pageState">前のセッションでこのページによって保存された状態の
        /// ディクショナリ。ページに初めてアクセスするとき、状態は null になります。</param>
        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
            // TODO: 問題のドメインでサンプル データを置き換えるのに適したデータ モデルを作成します
            var group = SampleDataSource.GetGroup((String)navigationParameter);
            this.DefaultViewModel["Group"] = group;
            this.DefaultViewModel["Items"] = group.Items;

            if (pageState == null)
            {
                this.itemListView.SelectedItem = null;
                // 新しいページの場合、論理ページ ナビゲーションが使用されている場合を除き、自動的に
                // 最初のアイテムを選択します (以下の論理ページ ナビゲーションの #region を参照)。
                if (!this.UsingLogicalPageNavigation() && this.itemsViewSource.View != null)
                {
                    this.itemsViewSource.View.MoveCurrentToFirst();
                }
            }
            else
            {
                // このページに関連付けられている、前に保存された状態を復元します
                if (pageState.ContainsKey("SelectedItem") && this.itemsViewSource.View != null)
                {
                    var selectedItem = SampleDataSource.GetItem((String)pageState["SelectedItem"]);
                    this.itemsViewSource.View.MoveCurrentTo(selectedItem);
                }
            }
        }

        /// <summary>
        /// アプリケーションが中断される場合、またはページがナビゲーション キャッシュから破棄される場合、
        /// このページに関連付けられた状態を保存します。値は、
        /// <see cref="SuspensionManager.SessionState"/> のシリアル化の要件に準拠する必要があります。
        /// </summary>
        /// <param name="pageState">シリアル化可能な状態で作成される空のディクショナリ。</param>
        protected override void SaveState(Dictionary<String, Object> pageState)
        {
            if (this.itemsViewSource.View != null)
            {
                var selectedItem = (SampleDataItem)this.itemsViewSource.View.CurrentItem;
                if (selectedItem != null) pageState["SelectedItem"] = selectedItem.UniqueId;
            }
        }

        #endregion

        #region 論理ページ ナビゲーション

        // 通常、表示状態管理では、アプリケーションの 4 つのビューステートが直接反映されます
        // (全画面表示の横向きビューおよび縦向きビュー、スナップ ビュー、フィル ビュー)。分割ページは、
        // スナップ ビューステートと縦向きビューステートが、それぞれ個別の 2 つのサブステートを所有できるようにします。
        // アイテム リストまたは詳細情報のどちらかは表示されますが、両方が同時に表示されることはありません。
        //
        // これはすべて、2 つの論理ページを表すことができる単一の物理ページと共に実装
        // されます。次のコードを使用すると、ユーザーに違いを感じさせることなく、この目的を達成することが
        // できます。

        /// <summary>
        /// 1 つの論理ページまたは 2 つの論理ページのどちらとしてページが動作するかを判断するために呼び出されます。
        /// </summary>
        /// <param name="viewState">問題が発生しているビューステートです。現在のビューステートの場合は 
        /// null です。これは、既定値が null のオプションのパラメーター
        /// です。</param>
        /// <returns>問題のビューステートが縦向きまたはスナップの場合は true、それ以外の場合は
        /// false です。</returns>
        private bool UsingLogicalPageNavigation(ApplicationViewState? viewState = null)
        {
            if (viewState == null) viewState = ApplicationView.Value;
            return viewState == ApplicationViewState.FullScreenPortrait ||
                viewState == ApplicationViewState.Snapped;
        }

        /// <summary>
        /// リスト内のアイテムが選択されたときに呼び出されます。
        /// </summary>
        /// <param name="sender">選択されたアイテムを表示する GridView (アプリケーションがスナップ
        /// されている場合は ListView) です。</param>
        /// <param name="e">選択がどのように変更されたかを説明するイベント データ。</param>
        void ItemListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // 選択内の変更によって現在の論理ページ内の該当箇所が変更されるため、
            // 論理ページ ナビゲーションが有効な場合にビューステートを無効にします。
            // アイテムが選択されている場合、アイテム リストの表示から、選択されたアイテムの詳細情報の表示に
            // 変更される効果があります。選択がクリアされると、逆に、アイテム リストが
            // 表示されます。
            if (this.UsingLogicalPageNavigation()) this.InvalidateVisualState();
        }

        /// <summary>
        /// ページの [戻る] がクリックされたときに呼び出されます。
        /// </summary>
        /// <param name="sender">[戻る] ボタンのインスタンス。</param>
        /// <param name="e">[戻る] がどのようにクリックされたかを説明するイベント データ。</param>
        protected override void GoBack(object sender, RoutedEventArgs e)
        {
            if (this.UsingLogicalPageNavigation() && itemListView.SelectedItem != null)
            {
                // 論理ページ ナビゲーションが有効で、アイテムが選択され、そのアイテムの
                // 詳細情報が現在表示されています。選択をクリアすると、アイテム リストに
                // 戻ります。ユーザーの立場から見ると、これは、論理的には前に戻る
                // 動作です。
                this.itemListView.SelectedItem = null;
            }
            else
            {
                // 論理ページ ナビゲーションが有効でないか、アイテムが選択されていない場合は
                // 既定の [戻る] の動作を使用します。
                base.GoBack(sender, e);
            }
        }

        /// <summary>
        /// アプリケーションのビューステートに対応する表示状態の名前を確認するために
        /// 呼び出されます。
        /// </summary>
        /// <param name="viewState">問題が発生しているビューステートです。</param>
        /// <returns>目的の表示状態の名前。これは、縦向きビューおよびスナップ 
        /// ビューでアイテムが選択され、_Detail というサフィックスが追加されたこの追加の論理ページが
        /// 存在している場合を除き、ビューステートの名前と同じです。</returns>
        protected override string DetermineVisualState(ApplicationViewState viewState)
        {
            // ビューステートが変更されたときに [戻る] が有効にされている状態を更新します
            var logicalPageBack = this.UsingLogicalPageNavigation(viewState) && this.itemListView.SelectedItem != null;
            var physicalPageBack = this.Frame != null && this.Frame.CanGoBack;
            this.DefaultViewModel["CanGoBack"] = logicalPageBack || physicalPageBack;

            // ビューステートではなくウィンドウの幅を基にして横向きレイアウトの表示状態を
            // 決定します。このページの 1 つのレイアウトは 1366 仮想ピクセル以上に適しており、
            // 別のレイアウトはより幅が狭いディスプレイや、スナップされたアプリケーションによって
            // 表示可能な横のスペースが 1366 未満に狭められている場合に適しています。
            if (viewState == ApplicationViewState.Filled ||
                viewState == ApplicationViewState.FullScreenLandscape)
            {
                var windowWidth = Window.Current.Bounds.Width;
                if (windowWidth >= 1366) return "FullScreenLandscapeOrWide";
                return "FilledOrNarrow";
            }

            // 既定の表示状態の名前で縦向きまたはスナップで開始される場合には、
            // リストではなく詳細を表示するときにサフィックスを追加します
            var defaultStateName = base.DetermineVisualState(viewState);
            return logicalPageBack ? defaultStateName + "_Detail" : defaultStateName;
        }

        #endregion
    }
}
