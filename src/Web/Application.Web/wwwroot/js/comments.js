(function () {
    var addNewComments = document.querySelectorAll("#addNewComment");
    addNewComments.forEach(x => {
        var comment = x.children.item(1);

        document.addEventListener('keypress', function (e) {
            if (e.key === 'Enter') {

                if (comment.value != "") {
                    execAjax(comment);
                }
            }
        });
    });

    function execAjax(comment) {

        var data = {
            content: comment.value,
            toPostId: comment.parentElement.accessKey
        };
        fetch("/api/comment",
            {
                method: "POST",
                headers: {
                    'X-CSRF-TOKEN': document.querySelector("#antiForgeryForm").querySelector("input").value,
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(data)
            })
            .then(res => res.json())
            .then(data => {
                comment.value = "";

                //var recentComment = createElementFromHTML(`<partial name="_SingleCommentPartial" model="${data}"/>`);
                var rawCommentView = '<div class="post-comment">' + 
                    `<img src="${data.fromUserProfileImagePath}" alt="" class="profile-photo-sm">` + 
                    `<p><a href="timeline.html" class="profile-link">${data.fromUsername} </a><i class="em em-laughing"></i>${data.content}</p>` + 
                    //`<div class="reaction">` + 
                    //`<a class="btn text-green" id="commentLikeBtn"><i class="fa fa-thumbs-up"></i></a><span id="commentLikeCount">${data.likesCount}</span>` + 
                    //`<a class="btn text-red" id="commentDislikeBtn"><i class="fa fa-thumbs-down"></i></a><span id="commentDislikeCount">${data.dislikesCount}</span>` + 
                    //`</div>
                    `</div >`
                var recentComment = createElementFromHTML(rawCommentView);
                var commentsContainer = comment.parentElement.parentElement.querySelector("#commentsContainer")
                commentsContainer.appendChild(recentComment);
            })
            .catch(x => console.log(x))
    }

    function createElementFromHTML(htmlString) {
        var div = document.createElement('div');
        div.innerHTML = htmlString.trim();

        // Change this to div.childNodes to support multiple top-level nodes
        return div.firstChild;
    }
})();