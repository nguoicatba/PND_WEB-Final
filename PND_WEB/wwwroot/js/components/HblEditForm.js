document.querySelectorAll('.form-check-input').forEach(cb => {
    cb.addEventListener('change', function () {
        if (this.checked) {
            document.querySelectorAll('.form-check-input').forEach(other => {
                if (other !== this) other.checked = false;
            });
        }
    });
});