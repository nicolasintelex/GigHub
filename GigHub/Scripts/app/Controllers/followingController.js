var FollowingController = function (followingService) {
    var button;

    var init = function () {
        $(".js-toggle-following").click(toggleFollowing);
    };

    var toggleFollowing = function (e) {
        button = $(e.target);
        var ArtistId = button.attr("data-artist-id");
        if (button.hasClass("btn-default"))
            followingService.createFollowing(ArtistId, done, fail)
        else
            followingService.deleteFollowing(ArtistId, done, fail)
    }

    var fail = function () {
        alert("Something failed");
    }

    var done = function () {
        var text = (button.text() == "Follow") ? "Following" : "Follow";
        button.toggleClass("btn-info").toggleClass("btn-default").text(text)
    }

    return {
        init: init
    }
}(FollowingService)

//$(".js-toggle-following").click(function (e) {
//    var button = $(e.target);
//    if (button.hasClass("btn-default")) {
//        $.post("/api/following", { FolloweeId: button.attr("data-artist-id") })
//            .done(function () {
//                button
//                    .removeClass("btn-default")
//                    .addClass("btn-info")
//                    .text("Following");
//            })
//            .fail(function () {
//                alert("something failed!");
//            });
//    } else {
//        $.ajax({
//            url: "/api/following/" + button.attr("data-artist-id"),
//            method: "DELETE"
//        })
//            .done(function () {
//                button
//                    .removeClass("btn-info")
//                    .addClass("btn-default")
//                    .text("Follow");
//            })
//            .fail(function () {
//                alert("something failed!");
//            });
//    }
//});