
document.addEventListener("DOMContentLoaded", function () {

    if (typeof confetti === 'function') {
        launchConfetti();
    } else {

        var script = document.createElement('script');
        script.src = 'https://cdn.jsdelivr.net/npm/canvas-confetti@1.5.1/dist/confetti.browser.min.js';
        script.onload = function () {
            launchConfetti();
        };
        document.head.appendChild(script);
    }
});

function launchConfetti() {

    confetti({
        particleCount: 150,
        spread: 90,
        origin: { y: 0.6 },
        colors: ['#4CAF50', '#2196F3', '#FFC107', '#9C27B0', '#FF5722']
    });


    setTimeout(() => {
        confetti({
            particleCount: 100,
            spread: 180,
            startVelocity: 30,
            origin: { y: 0.4 },
            colors: ['#4CAF50', '#2196F3', '#FFC107', '#9C27B0', '#FF5722']
        });
    }, 500);


    setTimeout(() => {
        confetti({
            particleCount: 80,
            angle: 60,
            spread: 55,
            origin: { x: 0 },
            colors: ['#4CAF50', '#2196F3', '#FFC107']
        });
        confetti({
            particleCount: 80,
            angle: 120,
            spread: 55,
            origin: { x: 1 },
            colors: ['#9C27B0', '#FF5722', '#4CAF50']
        });
    }, 1200);
}