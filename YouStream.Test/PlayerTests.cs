using Bunit;
using MudBlazor.Services;
using YouStream.Pages;

namespace YouStream.Test;

public class PlayerTests
{
    [Fact]
    public void TestVideoSource()
    {
        //Params
        string expectedUrl = "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ElephantsDream.mp4";

        //Arrange
        var context = new TestContext();
        context.Services.AddMudServices();
        var component = context.RenderComponent<VideoStream>();
        var selectionElement = component.FindAll("p").Where(value => value.TextContent == "Elephant Dream").First();
        var videoPlayer = component.Find("video");

        //Act
        selectionElement.Click();

        //Assert
        Assert.Equal(expectedUrl, videoPlayer.GetElementsByTagName("source").First().GetAttribute("src"));
    }

    [Fact]
    public void TestIfVideoPosterChangesOnSelection()
    {
        //Arrange
        var context = new TestContext();
        context.Services.AddMudServices();
        var component = context.RenderComponent<VideoStream>();
        var selectionElement = component.FindAll("p").Where(value => value.TextContent == "Elephant Dream").First();
        var videoPlayer = component.Find("video");

        //Act
        selectionElement.Click();

        //Assert
        Assert.Equal("/images/ED.jpeg", videoPlayer.GetAttribute("poster"));
    }
}
