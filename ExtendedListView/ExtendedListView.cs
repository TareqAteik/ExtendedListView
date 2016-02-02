using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Foundation;
using Windows.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

// The Templated Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234235

namespace ExtendedListView
{
    public class ExtendedListView : ListView
    {
        public bool IsPullToRefreshEnabled
        {
            get { return (bool)GetValue(ExtendedListView.IsPullToRefreshEnabledProperty); }
            set { SetValue(ExtendedListView.IsPullToRefreshEnabledProperty, value); }
        }

        public static bool GetIsPullToRefreshEnabled(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsPullToRefreshEnabledProperty);
        }

        public static void SetIsPullToRefreshEnabled(DependencyObject obj, bool value)
        {
            obj.SetValue(IsPullToRefreshEnabledProperty, value);
        }

        // Using a DependencyProperty as the backing store for IsPullToRefreshEnabled.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsPullToRefreshEnabledProperty =
            DependencyProperty.RegisterAttached("IsPullToRefreshEnabled", typeof(bool), typeof(ExtendedListView), new PropertyMetadata(false, OnPullToRefreshEnabledChanged));

        private static void OnPullToRefreshEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var list = d as ExtendedListView;
            var refreshPart = list.GetTemplateChild("refreshPart") as FrameworkElement;
            var scrollViewer = list.GetTemplateChild("scrollViewer") as ScrollViewer;
            if (refreshPart == null || scrollViewer == null) return;
            if ((bool)e.NewValue)
            {
                refreshPart.Opacity = 1;
                scrollViewer.ChangeView(null, refreshPart.RenderSize.Height, null, true);
                scrollViewer.UpdateLayout();
            }
            else
            {
                refreshPart.Opacity = 0.0;
            }
        }


        public bool IsMoreDataRequestedEnabled
        {
            get { return (bool)GetValue(ExtendedListView.IsMoreDataRequestedEnabledProperty); }
            set { SetValue(ExtendedListView.IsMoreDataRequestedEnabledProperty, value); }
        }
        public static bool GetIsMoreDataRequestedEnabled(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsMoreDataRequestedEnabledProperty);
        }

        public static void SetIsMoreDataRequestedEnabled(DependencyObject obj, bool value)
        {
            obj.SetValue(IsMoreDataRequestedEnabledProperty, value);
        }

        // Using a DependencyProperty as the backing store for IsMoreDataRequestedEnabled.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsMoreDataRequestedEnabledProperty =
            DependencyProperty.RegisterAttached("IsMoreDataRequestedEnabled", typeof(bool), typeof(ExtendedListView), new PropertyMetadata(false));



        public DataTemplate LoadingPartTemplate
        {
            get { return (DataTemplate)GetValue(ExtendedListView.LoadingPartTemplateProperty); }
            set { SetValue(ExtendedListView.LoadingPartTemplateProperty, value); }
        }

        public static DataTemplate GetLoadingPartTemplate(DependencyObject obj)
        {
            return (DataTemplate)obj.GetValue(LoadingPartTemplateProperty);
        }

        public static void SetLoadingPartTemplate(DependencyObject obj, DataTemplate value)
        {
            obj.SetValue(LoadingPartTemplateProperty, value);
        }

        // Using a DependencyProperty as the backing store for LoadingPartTemplate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LoadingPartTemplateProperty =
            DependencyProperty.RegisterAttached("LoadingPartTemplate", typeof(DataTemplate), typeof(ExtendedListView), new PropertyMetadata(null));




        public DataTemplate PullToRefreshPartTemplate
        {
            get { return (DataTemplate)GetValue(ExtendedListView.PullToRefreshPartTemplateProperty); }
            set { SetValue(ExtendedListView.PullToRefreshPartTemplateProperty, value); }
        }
        public static DataTemplate GetPullToRefreshPartTemplate(DependencyObject obj)
        {
            return (DataTemplate)obj.GetValue(PullToRefreshPartTemplateProperty);
        }

        public static void SetPullToRefreshPartTemplate(DependencyObject obj, DataTemplate value)
        {
            obj.SetValue(PullToRefreshPartTemplateProperty, value);
        }

        // Using a DependencyProperty as the backing store for PullToRefreshPartTemplate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PullToRefreshPartTemplateProperty =
            DependencyProperty.RegisterAttached("PullToRefreshPartTemplate", typeof(DataTemplate), typeof(ExtendedListView), new PropertyMetadata(null));



        public DataTemplate MoreDataProgressTemplate
        {
            get { return (DataTemplate)GetValue(ExtendedListView.MoreDataProgressTemplateProperty); }
            set { SetValue(ExtendedListView.MoreDataProgressTemplateProperty, value); }
        }
        public static DataTemplate GetMoreDataProgressTemplate(DependencyObject obj)
        {
            return (DataTemplate)obj.GetValue(MoreDataProgressTemplateProperty);
        }

        public static void SetMoreDataProgressTemplate(DependencyObject obj, DataTemplate value)
        {
            obj.SetValue(MoreDataProgressTemplateProperty, value);
        }

        // Using a DependencyProperty as the backing store for MoreDataProgressTemplate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MoreDataProgressTemplateProperty =
            DependencyProperty.RegisterAttached("MoreDataProgressTemplate", typeof(DataTemplate), typeof(ExtendedListView), new PropertyMetadata(null));



        //public AsyncDelegateCommand PullToRefreshRequestedAsyncCommand
        //{
        //    get
        //    {
        //        if (PullToRefreshRequestedAsyncCommand!=null && !(PullToRefreshRequestedAsyncCommand is AsyncDelegateCommand))
        //            throw new ArgumentException("AsyncDelegateCommand type should be used to implement ICommand");
        //        return (AsyncDelegateCommand)GetValue(ExtendedListView.PullToRefreshRequestedCommandProperty);
        //    }
        //    set { SetValue(ExtendedListView.PullToRefreshRequestedCommandProperty, value); }
        //}
        //public static AsyncDelegateCommand GetPullToRefreshRequestedCommand(DependencyObject obj)
        //{
        //    return (AsyncDelegateCommand)obj.GetValue(PullToRefreshRequestedCommandProperty);
        //}

        //public static void SetPullToRefreshRequestedCommand(DependencyObject obj, AsyncDelegateCommand value)
        //{
        //    obj.SetValue(PullToRefreshRequestedCommandProperty, value);
        //}

        //// Using a DependencyProperty as the backing store for PullToRefreshRequestedCommand.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty PullToRefreshRequestedCommandProperty =
        //    DependencyProperty.RegisterAttached("PullToRefreshRequestedAsyncCommand", typeof(AsyncDelegateCommand), typeof(ExtendedListView), new PropertyMetadata(null));


        //public object PullToRefreshRequestedCommandParameter
        //{
        //    get { return GetValue(ExtendedListView.PullToRefreshRequestedCommandParameterProperty); }
        //    set { SetValue(ExtendedListView.PullToRefreshRequestedCommandParameterProperty, value); }
        //}
        //public static object GetPullToRefreshRequestedCommandParameter(DependencyObject obj)
        //{
        //    return (object)obj.GetValue(PullToRefreshRequestedCommandParameterProperty);
        //}

        //public static void SetPullToRefreshRequestedCommandParameter(DependencyObject obj, object value)
        //{
        //    obj.SetValue(PullToRefreshRequestedCommandParameterProperty, value);
        //}

        //// Using a DependencyProperty as the backing store for PullToRefreshRequestedCommandParameter.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty PullToRefreshRequestedCommandParameterProperty =
        //    DependencyProperty.RegisterAttached("PullToRefreshRequestedCommandParameter", typeof(object), typeof(ExtendedListView), new PropertyMetadata(null));


        //public AsyncDelegateCommand MoreDataRequestedAsyncCommand
        //{
        //    get
        //    {
        //        if (MoreDataRequestedAsyncCommand!=null && !(MoreDataRequestedAsyncCommand is AsyncDelegateCommand))
        //            throw new ArgumentException("AsyncDelegateCommand type should be used to implement ICommand"); 
        //        return (AsyncDelegateCommand)GetValue(ExtendedListView.MoreDataRequestedAsyncCommandProperty);
        //    }
        //    set { SetValue(ExtendedListView.MoreDataRequestedAsyncCommandProperty, value); }
        //}
        //public static AsyncDelegateCommand GetMoreDataRequestedAsyncCommand(DependencyObject obj)
        //{
        //    return (AsyncDelegateCommand)obj.GetValue(MoreDataRequestedAsyncCommandProperty);
        //}

        //public static void SetMoreDataRequestedAsyncCommand(DependencyObject obj, AsyncDelegateCommand value)
        //{
        //    obj.SetValue(MoreDataRequestedAsyncCommandProperty, value);
        //}

        //// Using a DependencyProperty as the backing store for MoreDataRequestedAsyncCommand.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty MoreDataRequestedAsyncCommandProperty =
        //    DependencyProperty.RegisterAttached("MoreDataRequestedAsyncCommand", typeof(AsyncDelegateCommand), typeof(ExtendedListView), new PropertyMetadata(null));


        //public object MoreDataRequestedAsyncCommandParameter
        //{
        //    get { return GetValue(ExtendedListView.MoreDataRequestedAsyncCommandParameterProperty); }
        //    set { SetValue(ExtendedListView.MoreDataRequestedAsyncCommandParameterProperty, value); }
        //}
        //public static object GetMoreDataRequestedAsyncCommandParameter(DependencyObject obj)
        //{
        //    return (object)obj.GetValue(MoreDataRequestedAsyncCommandParameterProperty);
        //}

        //public static void SetMoreDataRequestedAsyncCommandParameter(DependencyObject obj, object value)
        //{
        //    obj.SetValue(MoreDataRequestedAsyncCommandParameterProperty, value);
        //}

        //// Using a DependencyProperty as the backing store for MoreDataRequestedAsyncCommandParameter.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty MoreDataRequestedAsyncCommandParameterProperty =
        //    DependencyProperty.RegisterAttached("MoreDataRequestedAsyncCommandParameter", typeof(object), typeof(ExtendedListView), new PropertyMetadata(null));


        public new event SelectionChangedEventHandler SelectionChanged;
        public new event TypedEventHandler<ListViewBase, ContainerContentChangingEventArgs> ContainerContentChanging;
        public new event DragItemsStartingEventHandler DragItemsStarting;
        public new event ItemClickEventHandler ItemClick;
        public new event HoldingEventHandler Holding;
        public new event RightTappedEventHandler RightTapped;

        public event AsyncEventHandler PullToRefreshRequested;
        public event AsyncEventHandler MoreDataRequested;

        public delegate Task AsyncEventHandler(object sender, EventArgs e);

        private ScrollViewer scrollViewer;
        bool _isPullRefresh = false;
        FrameworkElement refreshPart, loading, pullToRefresh, container, text, moreDataProgressBar;
        //ScrollViewer listScrollViewer;
        //ItemsPresenter list;
        ListView listView;
        ScrollViewer listViewScollViewer;
        public ExtendedListView()
        {
            this.DefaultStyleKey = typeof(ExtendedListView);
        }

        public new void ScrollIntoView(object view)
        {
            if (listView != null)
                listView.ScrollIntoView(view);
        }
        public new void SelectAll()
        {
            listView.SelectAll();
        }
        public new void ScrollIntoView(object view, ScrollIntoViewAlignment alignment)
        {
            if (listView != null)
                listView.ScrollIntoView(view, alignment);
        }
        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                return;
            }
            var g = (FindChildControl<Grid>(this, "") as Grid);
            var c = (GetTemplateChild("loading") as ContentPresenter);
            if (c.ContentTemplate == null)
                c.ContentTemplate = g.Resources["refreshPartTemplate"] as DataTemplate;

            c = (GetTemplateChild("pullToRefresh") as ContentPresenter);
            if (c.ContentTemplate == null)
                c.ContentTemplate = g.Resources["pullToRefreshTemplate"] as DataTemplate;

            c = (GetTemplateChild("moreDataProgressBar") as ContentPresenter);
            if (c.ContentTemplate == null)
                c.ContentTemplate = g.Resources["moreDataProgressBarTemplate"] as DataTemplate;

            moreDataProgressBar = GetTemplateChild("moreDataProgressBar") as FrameworkElement;
            moreDataProgressBar.Visibility = Windows.UI.Xaml.Visibility.Collapsed;

            refreshPart = GetTemplateChild("refreshPart") as FrameworkElement;
            loading = GetTemplateChild("loading") as FrameworkElement;
            pullToRefresh = GetTemplateChild("pullToRefresh") as FrameworkElement;
            scrollViewer = GetTemplateChild("scrollViewer") as ScrollViewer;
            //listScrollViewer = GetTemplateChild("listScrollViewer") as ScrollViewer;
            container = GetTemplateChild("container") as FrameworkElement;
            //list = GetTemplateChild("list") as ItemsPresenter;

            listView = GetTemplateChild("listView") as ListView;

            if (IsPullToRefreshEnabled)
            {
                refreshPart.Opacity = 1;
                scrollViewer.ChangeView(null, refreshPart.RenderSize.Height, null, true);
                scrollViewer.UpdateLayout();
            }
            else
            {
                refreshPart.Opacity = 0.0;
            }
            listView.Loaded += (s, ea) =>
            {
                isBusy = false;
            };
            scrollViewer.Loaded += async(s, ea) =>
            {
                scrollViewer.ChangeView(null, refreshPart.RenderSize.Height, null, true);
                listView.Width = listView.Width - 1;
                listView.Height = listView.Height - 1;

                //list.Height = list.Height + 1;
                //list.Width = list.Width + 1;

                await Task.Delay(10);


                listView.Width = listView.Width + 1;
                listView.Height = listView.Height + 1;
                //list.Height = list.Height - 1;
                //list.Width = list.Width - 1;
                Windows.System.Threading.ThreadPoolTimer.CreateTimer(async (source) =>
                {
                    await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                    {
                        scrollViewer.ChangeView(null, refreshPart.RenderSize.Height, null, true);//TODO
                    });
                }, TimeSpan.FromMilliseconds(10));
            };

            Windows.Graphics.Display.DisplayInformation.GetForCurrentView().OrientationChanged += (s, ea) =>
            {
                isOrientation = true;
            };
            SizeChangedEventHandler handler = null;
            handler = delegate(object sender, SizeChangedEventArgs ea)
            {
                //while (this.Parent == null)
                //{
                //    await Task.Delay(100);
                //}
                //if (ea.NewSize.Height >= Window.Current.Content.RenderSize.Height + refreshPart.RenderSize.Height)
                //{
                //    listScrollViewer.Width = ea.NewSize.Width;
                //    listScrollViewer.Height = Window.Current.Content.RenderSize.Height;

                //    list.Height = Window.Current.Content.RenderSize.Height;
                //    scrollViewer.Height = Window.Current.Content.RenderSize.Height;
                //    list.Width = ea.NewSize.Width;
                //    await Task.Delay(100);
                //    scrollViewer.ChangeView(null, refreshPart.RenderSize.Height, null, true);//TODO
                //    return;
                //}
                if (this.Parent is StackPanel) return;
                //listScrollViewer.Width = ea.NewSize.Width;
                //listScrollViewer.Height = ea.NewSize.Height;

                listView.Height = ea.NewSize.Height;
                listView.Width = ea.NewSize.Width;
                Windows.System.Threading.ThreadPoolTimer.CreateTimer(async (source) => {
                    await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                    {
                        scrollViewer.ChangeView(null, refreshPart.RenderSize.Height, null, true);//TODO
                    });
                }, TimeSpan.FromMilliseconds(10));
            };
            scrollViewer.SizeChanged += handler;

            this.AddHandler(PointerPressedEvent, new PointerEventHandler(OnPrssed), true);
            this.AddHandler(PointerWheelChangedEvent, new PointerEventHandler(OnWheel), true);
            scrollViewer.ViewChanged += scrollViewer_ViewChanged;
            //list.Holding += (s, ea) =>
            //{
            //    this.UpdateLayout();
            //    if (ea.HoldingState == Windows.UI.Input.HoldingState.Started)
            //    {
            //        var selEl = ContainerFromIndex(this.SelectedIndex) as FrameworkElement;
            //        for (int i = 0; i < Items.Count; i++)
            //        {
            //            var el = this.ContainerFromIndex(i) as FrameworkElement;
            //            if (selEl != el)
            //                el.Opacity = 0.5;
            //            else
            //                el.Opacity = 1;
            //        }
            //        this.SelectedIndex = -1;
            //    }
            //};
            //listScrollViewer.Loaded += (s, ea) =>
            //{
            //    var x = list.RenderSize.Height;
            //};
            listView.SelectionChanged += (s, ea) =>
            {
                if (SelectionChanged != null)
                    SelectionChanged(this, ea);
            };
            listView.DragItemsStarting += (s, ea) =>
            {
                if (DragItemsStarting != null)
                    DragItemsStarting(this, ea);
            };
            listView.ItemClick += (s, ea) =>
            {
                if (ItemClick != null)
                    ItemClick(this, ea);
            };
            listView.ContainerContentChanging += (s, ea) =>
            {
                if (ContainerContentChanging != null)
                    ContainerContentChanging(this, ea);
            };
            listView.Holding += (s, ea) =>
            {
                if (Holding != null)
                    Holding(this, ea);
            };
            listView.RightTapped += (s, ea) =>
            {
                if (RightTapped != null)
                    RightTapped(this, ea);
            };
            listView.Loaded += (s1, ea1) =>
            {
                if (listViewScollViewer == null)
                {
                    listViewScollViewer = FindChildControl<ScrollViewer>(listView, "") as ScrollViewer;
            listViewScollViewer.ViewChanged += async (s, ea) =>
            {
                if (isBusy) return;
                if (IsMoreDataRequestedEnabled)
                    if (!ea.IsIntermediate)
                    {
                        if (listViewScollViewer.VerticalOffset == listViewScollViewer.ScrollableHeight)
                        {
                            if (MoreDataRequested != null)
                            {
                                moreDataProgressBar.Visibility = Visibility.Visible;
                                isBusy = true;
                                try
                                {
                                    await MoreDataRequested(this, EventArgs.Empty);
                                    //if (MoreDataRequestedAsyncCommand != null)
                                    //{
                                    //    await MoreDataRequestedAsyncCommand.ExecuteAsync(MoreDataRequestedAsyncCommandParameter);
                                    //}
                                }
                                catch (Exception e)
                                {
                                    isBusy = false;
                                    moreDataProgressBar.Visibility = Visibility.Collapsed;
                                    throw e;
                                }
                                isBusy = false;
                                moreDataProgressBar.Visibility = Visibility.Collapsed;
                            }
                        }
                    }
            };
                }
            };
            
            if (this.Parent != null && this.Parent is StackPanel)
            {
                pullToRefresh.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            }
        }
        bool isBusy = true;
        private void OnWheel(object sender, PointerRoutedEventArgs e)
        {
            isTouch = false;
        }

        private void OnPrssed(object sender, PointerRoutedEventArgs e)
        {
            isTouch = e.Pointer.PointerDeviceType == Windows.Devices.Input.PointerDeviceType.Touch;
        }
        bool isTouch = true;
        bool isOrientation = false;
        async void scrollViewer_ViewChanged(object sender, ScrollViewerViewChangedEventArgs ea)
        {
            if (!IsPullToRefreshEnabled || !isTouch || isBusy || isOrientation)
            {
                isOrientation = false;
                if (scrollViewer.VerticalOffset < refreshPart.RenderSize.Height)
                {
                    scrollViewer.ChangeView(null, refreshPart.RenderSize.Height, null, true);
                }
                return;
            }


            refreshPart.Opacity = 1 - scrollViewer.VerticalOffset / 100.0f;

            //var planeProject = text.Projection as PlaneProjection;
            //planeProject.RotationZ += scrollViewer.VerticalOffset;
            //var transform = text.RenderTransform as RotateTransform;
            //transform.Angle = 180 - scrollViewer.VerticalOffset -60;
            if (scrollViewer.VerticalOffset == 0)
            {
                refreshPart.Opacity = 1.0;
            }
            else
            {
                refreshPart.Opacity = 0.5;
            }

            if (scrollViewer.VerticalOffset != 0)
                _isPullRefresh = true;

            if (!ea.IsIntermediate)
            {
                if (scrollViewer.VerticalOffset <= 5 && _isPullRefresh)
                {
                    if (PullToRefreshRequested != null)
                    {
                        loading.Opacity = 1.0;
                        pullToRefresh.Opacity = 0.0;
                        try
                        {
                            isBusy = true;
                            await PullToRefreshRequested(this, EventArgs.Empty);

                            //if (PullToRefreshRequestedAsyncCommand != null && PullToRefreshRequestedAsyncCommand.CanExecute(PullToRefreshRequestedCommandParameter))
                            //{
                            //    await PullToRefreshRequestedAsyncCommand.ExecuteAsync(PullToRefreshRequestedCommandParameter);
                            //}
                            isBusy = false;
                        }
                        catch (Exception e)
                        {
                            _isPullRefresh = false;
                            scrollViewer.ChangeView(null, refreshPart.RenderSize.Height, null);
                            loading.Opacity = 0.0;
                            pullToRefresh.Opacity = 1.0;

                            throw e;
                        }
                    }
                }
                _isPullRefresh = false;
                scrollViewer.ChangeView(null, refreshPart.RenderSize.Height, null);
                await Task.Delay(10);
                loading.Opacity = 0.0;
                pullToRefresh.Opacity = 1.0;
            }

        }
        public DependencyObject FindChildControl<T>(DependencyObject control, string ctrlName)
        {
            int childNumber = VisualTreeHelper.GetChildrenCount(control);
            for (int i = 0; i < childNumber; i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(control, i);
                FrameworkElement fe = child as FrameworkElement;
                // Not a framework element or is null
                if (fe == null) return null;
                if (string.IsNullOrEmpty(ctrlName) && child is T)
                    return child;
                else if (child is T && fe.Name == ctrlName)
                {
                    // Found the control so return
                    return child;
                }
                else
                {
                    // Not found it - search children
                    DependencyObject nextLevel = FindChildControl<T>(child, ctrlName);
                    if (nextLevel != null)
                        return nextLevel;
                }
            }
            return null;
        }
    }
    //public class AsyncDelegateCommand : ICommand
    //{
    //    protected readonly Predicate<object> _canExecute;
    //    protected Func<object, Task> _asyncExecute;

    //    public event EventHandler CanExecuteChanged;

    //    public AsyncDelegateCommand(Func<object, Task> execute)
    //        : this(execute, null)
    //    {
    //    }

    //    public AsyncDelegateCommand(Func<object, Task> asyncExecute,
    //                   Predicate<object> canExecute)
    //    {
    //        _asyncExecute = asyncExecute;
    //        _canExecute = canExecute;
    //    }

    //    public bool CanExecute(object parameter)
    //    {
    //        if (_canExecute == null)
    //        {
    //            return true;
    //        }

    //        return _canExecute(parameter);
    //    }

    //    public async void Execute(object parameter)
    //    {
    //        await ExecuteAsync(parameter);
    //    }

    //    public virtual async Task ExecuteAsync(object parameter)
    //    {
    //        await _asyncExecute(parameter);
    //    }
    //}


}
