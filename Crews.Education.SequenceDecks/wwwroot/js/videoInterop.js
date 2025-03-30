export function playVideo(videoElement) {
    videoElement.play();
}

export function pauseVideo(videoElement) {
    videoElement.pause();
}

export function registerTimeUpdate(videoElement, dotNetHelper) {
    videoElement._dotNetHelper = dotNetHelper;

    videoElement._timeUpdateCallback = function () {
        const currentTimeInSeconds = videoElement.currentTime;
        const durationInSeconds = videoElement.duration;

        dotNetHelper.invokeMethodAsync('OnTimeUpdateAsync', currentTimeInSeconds, durationInSeconds);
    };

    videoElement.addEventListener('timeupdate', videoElement._timeUpdateCallback);
}

export function unregisterTimeUpdate(videoElement) {
    if (videoElement._timeUpdateCallback) {
        videoElement.removeEventListener('timeupdate', videoElement._timeUpdateCallback);
        videoElement._timeUpdateCallback = null;
        videoElement._dotNetHelper = null;
    }
}