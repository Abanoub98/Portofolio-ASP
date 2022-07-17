//variables declaration start
const nextPage = document.getElementById("nextPage");
const prevPage = document.getElementById("previousPage");
const pagesLinks = document.getElementById("pagesItemsList");
//variables declaration end


// helper functions start
function previousPageClicked()
{
    if(prevPage.classList.contains("disabled"))
    {
        return;
    }
    for(let i = 0; i < pagesLinks.children.length; i++)
    {
        if(pagesLinks.children[i].classList.contains("active"))
        {
            let newHref = href + (parseInt(pagesLinks.children[i].firstChild.innerText) - 1);
            window.location.href = newHref
            break;
        }
    }
}

function nextPageClicked()
{
    if(nextPage.classList.contains("disabled"))
    {
        return;
    }
    for(let i = 0; i < pagesLinks.children.length - 1; i++)
    {
        if(pagesLinks.children[i].classList.contains("active"))
        {
            let newHref = href +(parseInt(pagesLinks.children[i].firstChild.innerText) + 1);
            window.location.href = newHref;
            console.log(newHref);
            break;
        }
    }
}
//helper functions end

/*
the formulas i used for the navigation pages creation algorithm
the creation loop starts from 1 all the way to the display count and the currentPage > displayCount
currentPage => k , displayCount => dc, calculatedPageNum => x
1- kth(index) = k - dc
2- ith(index of k) = kth(index) % dc
3- x(i) = k - ith(index of k) + i
*/

//variables for pagination start
let pagesList = document.getElementById("pagesItemsList");
const maxPageCount = parseInt(document.getElementById("maxPageCount").innerText);
const currentPage = parseInt(document.getElementById("currentPage").innerText);
const displayCount = parseInt(document.getElementById("displayCount").innerText);
const splitHref = window.location.href.split("?");
const href = splitHref[0] + "?page=";
//variables for pagination end

//eq 1 
const kthIndex =  currentPage - displayCount;

//eq 2
let ithIndex = kthIndex % displayCount;
//the last page in a row always produce ith index = 0
if(ithIndex === 0)
{
    ithIndex = displayCount;
}

let iterations = displayCount;

if(maxPageCount < displayCount)
{
    iterations = maxPageCount;
}

for(let i = 1; i <= iterations; i++)
{
    let x;
    if(currentPage > displayCount)
    {
        //eq 3
        x = currentPage - ithIndex + i;
    }
    else
    {
        x = i;
    }
    if( x > maxPageCount)
    {
        break;
    }
    //page nav item creation
    const listItem = document.createElement("li");
    listItem.classList.add("page-item");
    const pageLink = document.createElement("a");
    pageLink.classList.add("page-link");
    pageLink.href = href + x;
    pageLink.innerText = x;
    listItem.appendChild(pageLink);
    if(i === ithIndex || i === currentPage)
    {
        listItem.classList.add("active");
    }
    pagesList.insertBefore(listItem, nextPage);
    if(currentPage === maxPageCount && x === currentPage)
    {
        break;
    }
}

// disable previous page if first page is active
if(currentPage === 1)
{
    prevPage.classList.add("disabled");
}
else
{
    prevPage.classList.remove("disabled");
}

//disable next page if last page is active
if(currentPage === maxPageCount)
{
    nextPage.classList.add("disabled");
}
else
{
    nextPage.classList.remove("disabled");
}

//attach event listeners to previous and next page btns
prevPage.addEventListener('click', previousPageClicked);
nextPage.addEventListener('click', nextPageClicked);