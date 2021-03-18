(function is_loaded() {
    if (document.getElementById) {
        document.getElementById('preloader').style.visibility = 'hidden';
    } else {
        if (document.layers) {
            document.all.preloader.style.visibility = 'hidden';
        }
        else {
            document.all.preloader.style.visibility = 'hidden';
        }
    }
})();