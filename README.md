One of the features that is missing from the ListView control in WinRT is the “Pull to refresh”. This feature is supported natively on both Android and iOS controls, but unfortunately not on Windows. Some might argue that this doesn’t fit in Windows apps, and that we should use the App bar instead. For me I think its just intuitive for any smart phone user to swipe down a list and expect the app to refresh the content. Also the official facebook & twitter apps implement this feature, and I think they just made the apps better.

So I created a simple control that add this feature (and the “more data on demand). The control works as expected, you swipe down and the list will fire the event `PullToRefreshRequested`.

[![image](http://tareqateik.com/content/images/2016/02/lv1.jpg "image")](http://tareqateik.com/content/images/2016/02/lv1.jpg)


To use this feature you need to set the `IsPullToRefreshEnabled` to true, and register the event `PullToRefreshRequested`:

    <ctrl:FMExtendedListView x:Name="listView" PullToRefreshRequested="listView_PullToRefreshRequested" IsPullToRefreshEnabled="True" />

You can edit these templates and use your own by changing the templates `PullToRefreshPartTemplate` and `LoadingPartTemplate`:

```
<ctrl:FMExtendedListView.PullToRefreshPartTemplate>
    <DataTemplate>
        <TextBlock Text="Keep scrolling" Margin="25,0" FontSize="25" VerticalAlignment="Center" />
    </DataTemplate>
</ctrl:FMExtendedListView.PullToRefreshPartTemplate>
<ctrl:FMExtendedListView.LoadingPartTemplate>
    <DataTemplate>
        <StackPanel Orientation="Horizontal">
            <ProgressRing IsActive="True" VerticalAlignment="Center" />
            <TextBlock Text="Downloading ..." Margin="25,0" FontSize="25" VerticalAlignment="Center" />
        </StackPanel>
    </DataTemplate>
</ctrl:FMExtendedListView.LoadingPartTemplate>
```


## Load more on demand

Another feature that’s missing in the ListView control is to continue loading data once the user reaches to the end of the control. Although you can implement this feature using “[ISupportIncrementalLoading](https://msdn.microsoft.com/library/windows/apps/hh701916)”, but in my onion I think it’s broken by design.

To use this feature, you will need to set the `IsMoreDataRequestedEnabled` to True, and register the `MoreDataRequested` event:

    <ctrl:FMExtendedListView x:Name="listView" IsMoreDataRequestedEnabled="True" MoreDataRequested="listView_MoreDataRequested" />

By default, you will see a progress bar running in the bottom of the control:

[![image](http://tareqateik.com/content/images/2016/02/lv2.jpg "image")](http://tareqateik.com/content/images/2016/02/lv2.jpg)

This part can be customized by changing the `MoreDataProgressTemplate` template:

```
<ctrl:FMExtendedListView.MoreDataProgressTemplate>
  <DataTemplate>
    <TextBlock Text="Loading more data" Margin="25,0" FontSize="25" />
  </DataTemplate>
</ctrl:FMExtendedListView.MoreDataProgressTemplate>
```

### Set when the load on demand should be performed

You can set when the load of more items should be perform by setting `ScrollProgressToRequestMoreData` to a value of type `double` bigger than 0 and smaller or equal to 1 (`0.0 < value <= 1.0`):

    <ctrl:FMExtendedListView x:Name="listView" IsMoreDataRequestedEnabled="True" MoreDataRequested="listView_MoreDataRequested" ScrollProgressToRequestMoreData="0.6" />
For this to work `IsMoreDataRequestedEnabled` must be set to `true`. This value is used to calculate when the load should be done, so if you set 0.6 the load will be done when the user scrolls 60% of the screen. **This value defaults to 1.0 if not setted.**





You’re free to use this control for any free or commercial project

Feel free to open an Issue if you are having any trouble or want to suggest a feature!
