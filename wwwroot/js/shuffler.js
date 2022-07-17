const shuffleBtns = document.querySelector(".shuffle-btn-container").children;
const items = document.querySelector(".shuffle-container").children;

for (let btn of shuffleBtns) {
    btn.addEventListener('click', onShuffleBtnClick);
}

function onShuffleBtnClick(ev) {
    toggleActiveShuffle(ev);
    shuffle(ev);
}

function toggleActiveShuffle(ev) {
    for (let btn of shuffleBtns) {
        btn.classList.remove('active-shuffle');
    }
    ev.target.classList.toggle('active-shuffle');
}


function shuffle(ev) {
    const shuffleTag = ev.target.getAttribute('shuffle-tag');
    if (shuffleTag === 'ALL') {
        for (let item of items) {
            item.style.opacity = 1;
        }
        return;
    }
    for (let item of items) {
        const tag = item.getAttribute('shuffle-tag');
        if (tag === shuffleTag) {
            item.style.opacity = 1;
        } else {
            item.style.opacity = 0.5;
        }
    }
}