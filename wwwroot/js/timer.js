var hours = 0;
var minutes = 0;
var seconds = 0;
var timer;
var isStarted = false;

function startTimer() {
    if (!isStarted) {
        timer = setInterval(updateTimer, 1000);
        isStarted = true;
    } else {
        if ((hours != 0 || minutes != 0 || seconds != 0) && isStarted == false) {
            timer = setInterval(updateTimer, 1000);
            isStarted = false;
        } else if (isStarted == true) {
            //alert("isStarted = " + isStarted);
        }
    }
}

function updateTimer() {
    seconds++;
    if (seconds == 60) {
        seconds = 0;
        minutes++;
    }
    if (minutes == 60) {
        minutes = 0;
        hours++;
    }
    document.getElementById("hours").innerHTML = formatTime(hours);
    document.getElementById("minutes").innerHTML = formatTime(minutes);
    document.getElementById("seconds").innerHTML = formatTime(seconds);
}

function formatTime(time) {
    if (time < 10) {
        return "0" + time;
    } else {
        return time;
    }
}

function stopTimer() {
    if (isStarted) {
        clearInterval(timer);
        isStarted = false;
    } else {
        //alert("isStarted = " + isStarted);
    }
}

function resetTimer() {
    clearInterval(timer);
    isStarted = false;
    hours = 0;
    minutes = 0;
    seconds = 0;
    document.getElementById("hours").innerHTML = formatTime(hours);
    document.getElementById("minutes").innerHTML = formatTime(minutes);
    document.getElementById("seconds").innerHTML = formatTime(seconds);
}

const arrow = document.querySelector(".arrow");
const startBtn = document.getElementById("start");
const stopBtn = document.getElementById("stop");
const resetBtn = document.getElementById("reset");
let animation;

arrow.style.animationPlayState = "paused";

function startAnimation() {
    arrow.style.animationPlayState = "running";
    arrow.style.animation = "seconds 60s infinite steps(60)";
}

function stopAnimation() {
    arrow.style.animationPlayState = "paused";
    void arrow.offsetWidth;
}

function resetAnimation() {
    arrow.style.animationPlayState = "paused";
    arrow.style.animation = "none";
    void arrow.offsetWidth;
}

startBtn.addEventListener("click", function () {
    startTimer();
    startAnimation();
});

stopBtn.addEventListener("click", function () {
    stopTimer();
    stopAnimation();
});

resetBtn.addEventListener("click", function () {
    resetTimer();
    resetAnimation();
});
