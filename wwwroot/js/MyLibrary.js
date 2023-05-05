const myLibrary = {

    startAnimation: function (arrow) {
        this.resetAnimation(arrow);
        arrow.style.animationPlayState = "running";
        arrow.style.animation = "seconds 60s infinite steps(60)";
    },

    stopAnimation: function (arrow) {
        arrow.style.animationPlayState = "paused";
        void arrow.offsetWidth;
    },

    resetAnimation: function (arrow) {
        arrow.style.animationPlayState = "paused";
        arrow.style.animation = "none";
        void arrow.offsetWidth;
    },
    setHours: function (hoursSelect) {
        for (let i = 0; i <= 23; i++) {
            const option = document.createElement("option");
            option.value = i;
            option.text = i < 10 ? `0${i}` : i;
            hoursSelect.add(option);
        }
    },
    setMinSec: function (minutesSelect, secondsSelect) {
        for (let i = 0; i <= 59; i++) {
            const option = document.createElement("option");
            option.value = i;
            option.text = i < 10 ? `0${i}` : i;
            minutesSelect.add(option);
            secondsSelect.add(option.cloneNode(true));
        }
    },
};

// Экспортируем объект наружу для возможности его использования в других JS файлах
export default myLibrary;