// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function addOneProduct(ev, name) {
    let amount = parseInt(ev.target.parentNode.parentNode.children[1].textContent);

    let newValue = amount + 1;
    ev.target.parentNode.parentNode.children[1].textContent = newValue;

    if (newValue == 2)
        ev.target.parentNode.children[1].disabled = false;

    let price = parseFloat(ev.target.parentNode.parentNode.children[2].textContent.replace(",", "."))
    ev.target.parentNode.parentNode.children[3].textContent = (Math.round(price * newValue * 100) / 100).toFixed(2).toString().replace('.', ',');

    const totalCost = document.querySelector('#totalCost');
    totalCost.textContent = (Math.round((parseFloat(totalCost.textContent.replace(",", ".")) + price) * 100) / 100).toFixed(2).toString().replace('.', ',') + " $";

    setCookie(name);
}

function removeOneProduct(ev, name) {

    const date = new Date();
    date.setTime(date.getTime() + (3 * 60 * 60 * 1000));

    let value = parseInt(getValueOfCookie(name)) - 1;

    let expires = "expires=" + date.toUTCString();

    let newValue = parseInt(ev.target.parentNode.parentNode.children[1].textContent) - 1;
    ev.target.parentNode.parentNode.children[1].textContent = newValue;

    if(newValue <= 1) {
        ev.target.disabled = true;
    }

    let price = parseFloat(ev.target.parentNode.parentNode.children[2].textContent.replace(",", "."))
    ev.target.parentNode.parentNode.children[3].textContent = (Math.round(price * newValue * 100) / 100).toFixed(2).toString().replace('.', ',');

    const totalCost = document.querySelector('#totalCost');

    totalCost.textContent = (Math.round((parseFloat(totalCost.textContent.replace(",", ".")) - price) * 100) / 100).toFixed(2).toString().replace('.', ',') + " $";

    document.cookie = `${name}=${value}; expires=${expires}; path=/; SameSite=None; Secure`;
}

function setCookie(name) {
    const date = new Date();
    date.setTime(date.getTime() + (3 * 60 * 60 * 1000));

    let expires = "expires=" + date.toUTCString();
    let value = parseInt(getValueOfCookie(name)) + 1;

    document.cookie = `${name}=${value}; expires=${expires}; path=/; SameSite=None; Secure`;
}

function deleteCookie(name) {
    document.cookie = `${name}=; expires='Thu, 01 Jan 1970 00:00:00 UTC'; path=/`;
    window.location.reload();
}

function getValueOfCookie(name) {
    const cDecode = decodeURIComponent(document.cookie);
    const cArray = cDecode.split('; ');

    for (const element of cArray) {
        if (element) {
            const data = element.split('=');

            if (name === data[0])
                return data[1];
        }
    }

    return 0;
}
