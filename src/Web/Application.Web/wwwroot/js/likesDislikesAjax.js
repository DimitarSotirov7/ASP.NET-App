(function () {
    var likeElements = document.querySelectorAll("#likeBtn");
    var dislikesElements = document.querySelectorAll("#dislikeBtn");
    var postId;
    var isLike = false;
 

    likeElements.forEach(x => {
        var likeBtn = x.children.item(0);
        likeBtn.addEventListener("click", onClick);
    });

    dislikesElements.forEach(x => {
        var dislikeBtn = x.children.item(0);
        dislikeBtn.addEventListener("click", onClick);
    });

    function onClick(x) {
        postId = x.target.parentNode.parentNode.id;
        isLike = x.target.className.includes('up');

        var data = {
            isLike: isLike,
            postId: postId
        };

        var btnCount = x.target.parentNode.nextSibling;
        fetch("/api/thumbUpDown",
            {
                method: "POST",
                headers: {
                    'X-CSRF-TOKEN': document.querySelector("#antiForgeryForm").querySelector("input").value,
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(data)
            })
            .then(res => res.json())
            .then(data =>
            {
                if (isLike) {
                    btnCount.textContent = data.likesCount;
                }
                else {
                    btnCount.textContent = data.dislikesCount;
                }
            })
            .catch(x => console.log(x))
    }
})();
