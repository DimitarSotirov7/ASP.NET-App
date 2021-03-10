﻿(function () {

    var addToFriendsbtn = document.querySelector("#addToFriends");
    var cancelTheRequestBtn = document.querySelector("#cancelTheRequest");

    if (addToFriendsbtn) {
        addToFriendsbtn.addEventListener("click", addToFriendsHandler);
    }
    if (cancelTheRequestBtn) {
        cancelTheRequestBtn.addEventListener("click", cancelTheRequestHandler);
    }

    function addToFriendsHandler(x) {

        data = {
            toId: x.target.accessKey
        }

        fetch("/api/friendship",
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
                if (data.requesterId && data.responderId) {
                    x.target.textContent = "Cancel the request";
                    x.target.className = "btn btn-primary btn-sm btn-block";
                    x.target.id = "cancelTheRequest";
                }
            })
            .catch(x => console.log(x))
    }

    function cancelTheRequestHandler(x) {

        data = {
            toId: x.target.accessKey
        }

        fetch("/api/friendship/1",
            {
                method: "DELETE",
                headers: {
                    'X-CSRF-TOKEN': document.querySelector("#antiForgeryForm").querySelector("input").value,
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(data)
            })
            .then(res => res.json())
            .then(data => {
                if (data.requesterId && data.responderId) {
                    x.target.textContent = "Add to friends";
                    x.target.className = "btn btn-success btn-sm btn-block";
                    x.target.id = "addToFriends";
                }
            })
            .catch(x => console.log(x))
    }
})();
