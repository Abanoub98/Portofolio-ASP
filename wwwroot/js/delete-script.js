const deleteBtns = document.querySelectorAll('a[is-delete="1"]');
let clickedBtn;
deleteBtns.forEach((btn) => {
    btn.addEventListener('click', onDeleteClicked);
});

function onDeleteClicked(ev)
{
    ev.preventDefault();
    const deleteModal = document.getElementById("toggleDeleteModal");
    deleteModal.click();
    clickedBtn = ev.target;
}

const confirmDeleteBtn = document.getElementById("confirmDeleteBtn");
confirmDeleteBtn.addEventListener('click', () => {
    clickedBtn.removeEventListener('click', onDeleteClicked);
    console.log(clickedBtn);
    clickedBtn.click();
});

const cancelDeleteBtn = document.getElementById("cancelBtn");
cancelDeleteBtn.addEventListener('click', () => {
    const deleteModal = document.getElementById("toggleDeleteModal");
    deleteModal.click();
});