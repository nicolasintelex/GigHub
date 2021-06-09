var FollowingService = function () {

    var createFollowing = function (artistId, done, fail) {
        $.post("/api/following", { FolloweeId: artistId })
            .done(done)
            .fail(fail);
    }

    var deleteFollowing = function (artistId, done, fail) {
        $.ajax({
            url: "/api/following/" + artistId,
            method: "DELETE"
        })
            .done(done)
            .fail(fail);
    }

    return {
        createFollowing: createFollowing,
        deleteFollowing: deleteFollowing
    }

}();