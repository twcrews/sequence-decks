export function playVideo(videoElement) {
    videoElement.play();
}

export function registerTimeUpdate(videoElement, dotNetHelper) {
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
    }
}

export function registerCanPlayThrough(videoElement, dotNetHelper) {
    videoElement.load();

    if (videoElement.readyState > 2) {
        dotNetHelper.invokeMethodAsync('OnNextVideoCanPlayThrough');
        return;
    }

    videoElement._canPlayThroughCallback = function () {
        dotNetHelper.invokeMethodAsync('OnNextVideoCanPlayThrough');
        videoElement.removeEventListener('canplaythrough', videoElement._canPlayThroughCallback);
    }

    videoElement.addEventListener('canplaythrough', videoElement._canPlayThroughCallback);
}