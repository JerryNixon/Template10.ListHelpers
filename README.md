# ListHelpers
This library adds missing functionalities to ListView and GridView. Although this shares the Template 10 namespace, this library has no other connection to Template 10 and shares no code with that project. A single namespace just makes things easier.

## Custom Style for Selected Item
When the user selects an item in a list, the ListItem changes automatically. However, there is no style changes applied to your custom template. This [attached property](https://docs.microsoft.com/en-us/windows/uwp/xaml-platform/custom-attached-properties) allows you to specify custom styles for each scenario.

### Usage syntax

#### 1. Add a reference to this project

> Install-Package Template10.ListHelpers 

#### 2. Add a namespace reference to Template 10

> xmlns:helpers="using:Template10"

#### 3. Define your styles and the SelectorInfo 

````xml
<Style x:Key="ItemNormalStyle" TargetType="Grid">
    <Setter Property="RequestedTheme" Value="Dark" />
    <Setter Property="Background" Value="{ThemeResource ButtonPointerOverBackgroundThemeBrush}" />
</Style>
        
<Style x:Key="ItemSelectedStyle" TargetType="Grid">
    <Setter Property="RequestedTheme" Value="Light" />
    <Setter Property="Background" Value="{ThemeResource ButtonBackgroundThemeBrush}" />
</Style>

    <helpers:SelectorInfo
    x:Key="MySelectorInfo" 
    NormalStyle="{StaticResource ItemNormalStyle}"
    SelectedStyle="{StaticResource ItemSelectedStyle}" />

````

#### 4. Tell your `ListView` or `DataGrid` about SelectorInfo

````xml
<GridView 
        helpers:GridViewHelper.SelectedItemStyle="{StaticResource MySelectorInfo}"
        ItemTemplate="{StaticResource DataGridItemTemplate}">
</GridView>
````

````xml
<ListView 
    helpers:ListViewHelper.SelectedItemStyle="{StaticResource MySelectorInfo}"
    ItemTemplate="{StaticResource ListViewItemTemplate}" >
    <ListView.ItemContainerStyle>
        <Style TargetType="ListViewItem">
            <Setter Property="HorizontalContentAlignment" Value="Stretch" />
            <Setter Property="Padding" Value="0" />
        </Style>
    </ListView.ItemContainerStyle>
</ListView>
````
