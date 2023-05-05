import myLibrary from './MyLibrary.js';
// Получаем элементы выбора времени
const hoursSelect = $("#hours")[0];
const minutesSelect = $("#minutes")[0];
const secondsSelect = $("#seconds")[0];
// Заполняем элементы выбора времени значениями от 0 до 23 для часов, от 0 до 59 для минут и секунд

$(window).on("load", function () {
    window.setTimeout(function () {
        myLibrary.setHours(hoursSelect);
        myLibrary.setMinSec(minutesSelect, secondsSelect);
    }, 100);
});

// Получаем элементы управления таймером
const startButton = $("#start")[0];
const stopButton = $("#stop")[0];
const resetButton = $("#reset")[0];
stopButton.disabled = true;
// Получаем элементы отображения времени
const hoursDisplay = $("#hours-display")[0];
const minutesDisplay = $("#minutes-display")[0];
const secondsDisplay = $("#seconds-display")[0];

class Time {
    #hours
    #minutes
    #seconds
    constructor(hours, minutes, seconds) {
        this.#hours = hours;
        this.#minutes = minutes;
        this.#seconds = seconds;
    }
    setHours = (hours) => {
        this.#hours = hours;
    };
    setMinutes = (minutes) => {
        this.#minutes = minutes;
    };
    setSeconds = (seconds) => {
        this.#seconds = seconds;
    };

    getHours = () => {
        return this.#hours;
    }
    getMinutes = () => {
        return this.#minutes;
    }
    getSeconds = () => {
        return this.#seconds;
    }
}

class Timer extends Time{
    #intervalId
    constructor(hours, minutes, seconds, intervalId) {
        super(hours, minutes, seconds);
        this.#intervalId = intervalId;
    }
    // Обновление значений времени на странице
    updateDisplay = () => {
        hoursDisplay.textContent = this.getHours() < 10 ? `0${this.getHours()}` : this.getHours();
        minutesDisplay.textContent = this.getMinutes() < 10 ? `0${this.getMinutes()}` : this.getMinutes();
        secondsDisplay.textContent = this.getSeconds() < 10 ? `0${this.getSeconds()}` : this.getSeconds();
    };

// Обновление значений времени в объекте таймера на основе выбранных значений
    updateValues = () => {
        this.setHours(parseInt(hoursSelect.value));
        this.setMinutes(parseInt(minutesSelect.value));
        this.setSeconds(parseInt(secondsSelect.value));
        this.updateDisplay();
    };

// Запуск таймера
    start = () => {
        this.intervalId = setInterval(() => {
            if (this.getSeconds() === 0) {
                if (this.getMinutes() === 0) {
                    if (this.getHours() === 0) {
                        myLibrary.stopAnimation(arrow);
                        clearInterval(this.intervalId);
                        this.intervalId = null;
                        startButton.disabled = false;
                        stopButton.disabled = true;
                        return;
                    }
                    this.setHours(this.getHours() - 1);
                    this.setMinutes(59);
                } else {
                    this.setMinutes(this.getMinutes() - 1);
                }
                this.setSeconds(59);
            } else {
                this.setSeconds(this.getSeconds() - 1);
            }
            this.updateDisplay();
        }, 1000);
    };

// Остановка таймера
    stop = () => {
        myLibrary.stopAnimation(arrow);
        clearInterval(this.intervalId);
        this.intervalId = null;
    };

// Сброс значений времени и остановка таймера
    reset = () => {
        this.stop();
        this.setHours(0);
        this.setMinutes(0);
        this.setSeconds(0);
        this.updateDisplay();
        hoursSelect.value = 0;
        minutesSelect.value = 0;
        secondsSelect.value = 0;
        myLibrary.resetAnimation(arrow);
    };
}

// Объект таймера
const timer = new Timer(0, 0, 0, null);

// Устанавливаем обработчики событий на элементы управления таймером
startButton.addEventListener("click", () => {
    timer.updateValues();
    timer.start();
    startButton.disabled = true;
    stopButton.disabled = false;
});

stopButton.addEventListener("click", () => {
    timer.stop();
    stopButton.disabled = true;
});

resetButton.addEventListener("click", () => {
    timer.reset();
    startButton.disabled = false;
    stopButton.disabled = true;
});



const arrow = $(".arrow")[0];
const startBtn = $("#start")[0];
const stopBtn = $("#stop")[0];
const resetBtn = $("#reset")[0];

arrow.style.animationPlayState = "paused";

startBtn.addEventListener("click", function () {
    myLibrary.startAnimation(arrow);
});

stopBtn.addEventListener("click", function () {
    myLibrary.stopAnimation(arrow);
});

resetBtn.addEventListener("click", function () {
    myLibrary.stopAnimation(arrow);
});