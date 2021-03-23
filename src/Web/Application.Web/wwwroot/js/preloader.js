(function is_loaded() {
    if (document.getElementById('preloader')) {
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