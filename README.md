<blockquote></blockquote>
<p>One of the features that is missing from the ListView control in WinRT is the &ldquo;Pull to refresh&rdquo;. This feature is supported natively on both Android and iOS controls, but unfortunately not on Windows. Some might argue that this doesn&rsquo;t fit in Windows apps, and that we should use the App bar instead. For me I think its just intuitive for any smart phone user to swipe down a list and expect the app to refresh the content. Also the official facebook &amp; twitter apps implement this feature, and I think they just made the apps better.</p>
<p>So I created a simple control that add this feature (and the &ldquo;more data on demand). The control works as expected, you swipe down and the list will fire the event &ldquo;PullToRefreshRequested&rdquo;.</p>
<p><a href="http://tareqateik.com/content/images/2016/02/lv1.jpg"><img title="image" style="background-image: none; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-width: 0px;" border="0" alt="image" src="http://tareqateik.com/content/images/2016/02/lv1.jpg" width="1028" height="637" /></a></p>
<p>&nbsp;</p>
<p>To use this feature you need to set the &ldquo;IsPullToRefreshEnabled&rdquo; to true, and register the event &ldquo;PullToRefreshRequested&rdquo;:</p>
<p></p>
<pre><code>&lt;ctrl:ExtendedListView x:Name="listView" PullToRefreshRequested="listView_PullToRefreshRequested" IsPullToRefreshEnabled="True" /&gt;</code></pre>
<p>&nbsp;</p>
<p>You can edit these templates and use your own by changing the templates &ldquo;PullToRefreshPartTemplate&rdquo; &amp; &ldquo;LoadingPartTemplate&rdquo;:</p>
<p></p>
<pre><code>&lt;ctrl:ExtendedListView.PullToRefreshPartTemplate&gt;<br />&nbsp;&nbsp;&nbsp; &lt;DataTemplate&gt;<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;TextBlock Text="Keep scrolling" Margin="25,0" FontSize="25" VerticalAlignment="Center" /&gt;<br />&nbsp;&nbsp;&nbsp; &lt;/DataTemplate&gt;<br />&lt;/ctrl:ExtendedListView.PullToRefreshPartTemplate&gt;<br />&lt;ctrl:ExtendedListView.LoadingPartTemplate&gt;<br />&nbsp;&nbsp;&nbsp; &lt;DataTemplate&gt;<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;StackPanel Orientation="Horizontal"&gt;<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;ProgressRing IsActive="True" VerticalAlignment="Center" /&gt;<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;TextBlock Text="Downloading ..." Margin="25,0" FontSize="25" VerticalAlignment="Center" /&gt;<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/StackPanel&gt;<br />&nbsp;&nbsp;&nbsp; &lt;/DataTemplate&gt;<br />&lt;/ctrl:ExtendedListView.LoadingPartTemplate&gt;</code></pre>
<p>&nbsp;</p>
<h2>Load more on demand</h2>
<p>Another feature that&rsquo;s missing in the ListView control is to continue loading data once the user reaches to the end of the control. Although you can implement this feature using &ldquo;<a href="https://msdn.microsoft.com/library/windows/apps/hh701916">ISupportIncrementalLoading</a>&rdquo;, but in my onion I think it&rsquo;s broken by design.</p>
<p>To use this feature, you will need to set the &ldquo;IsMoreDataRequestedEnabled&rdquo; to True, and register the &ldquo;MoreDataRequested&rdquo; event:</p>
<p></p>
<pre><code>&lt;ctrl:ExtendedListView x:Name="listView" IsMoreDataRequestedEnabled="True" MoreDataRequested="listView_MoreDataRequested" /&gt;</code></pre>
<p>&nbsp;</p>
<p>By default, you will see a progress bar running in the bottom of the control:</p>
<p><a href="http://tareqateik.com/content/images/2016/02/lv2.jpg"><img title="image" style="background-image: none; padding-top: 0px; padding-left: 0px; display: inline; padding-right: 0px; border-width: 0px;" border="0" alt="image" src="http://tareqateik.com/content/images/2016/02/lv2.jpg" width="644" height="349" /></a></p>
<p>This part can be customized by changing the &ldquo;MoreDataProgressTemplate&rdquo; template:</p>
<p></p>
<pre><code>&lt;ctrl:ExtendedListView.MoreDataProgressTemplate&gt;<br />&nbsp;&nbsp;&nbsp; &lt;DataTemplate&gt;<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;TextBlock Text="Loading more data" Margin="25,0" FontSize="25" /&gt;<br />&nbsp;&nbsp;&nbsp; &lt;/DataTemplate&gt;<br />&lt;/ctrl:ExtendedListView.MoreDataProgressTemplate&gt;</code></pre>
<p>&nbsp;</p>
<p>You can find the control by searching for &ldquo;<a href="https://www.nuget.org/packages/ExtendedListView">ExtendedListView</a>&rdquo; on Nuget, or by typing the following command in the Nuget console:</p>
<pre><code>Install-Package ExtendedListview</code></pre>
<p>You&rsquo;re free to use this control for any free or commercial project</p>
<p>Please reach me for any feature request (or bugs report) on Twitter <a href="https://twitter.com/TareqAteik">@TareqAteik</a></p>
