function onEditClick(event){
    const editBtn = event.target;
    const serviceId = editBtn.getAttribute("service-id");
    const serviceName = editBtn.getAttribute("service-name");
    const serviceDescription = editBtn.getAttribute("service-description");
    const editForm = document.querySelector("#editServiceForm");
    const idInput = editForm.querySelector("input[type='hidden'][name='Id']");
    idInput.value = serviceId;
    const nameInput = editForm.querySelector("input[name='Name']");
    nameInput.value = serviceName;
    const descriptionInput = editForm.querySelector("textarea[name='Description']");
    descriptionInput.textContent = serviceDescription;
}

const editButtons = document.querySelectorAll(".service-edit");
for(let btn of editButtons)
{
    btn.addEventListener('click', onEditClick);
}

const editForm = document.querySelector("#editServiceForm");
editForm.addEventListener('submit', (ev)=>{
    ev.preventDefault();
    const fileInput = editForm.querySelector("input[name='ServiceImage']");
    if(fileInput.files.length == 0)
    {
        fileInput.disabled = true;
    }else
    {
        fileInput.disabled = false;
    }
    editForm.submit();
});

const createForm = document.querySelector("#createServiceForm");
createForm.addEventListener('submit', (ev)=>{
    ev.preventDefault();
    const fileInput = createForm.querySelector("input[name='ServiceImage']");
    if(fileInput.files.length == 0)
    {
        fileInput.disabled = true;
    }else
    {
        fileInput.disabled = false;
    }
    createForm.submit();
});