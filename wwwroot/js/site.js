// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

/*displayAllCookies();*/
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

//function displayAllCookies() {
//    if (window.location.href === "https://localhost:7180/Home/Basket") {

//        const cDecode = decodeURIComponent(document.cookie);
//        const cArray = cDecode.split('; ');

//        const table = document.getElementById('basket');

//        cArray.forEach(element => {
//            if (element) {
//                const data = element.split('=');

//                let isKit = data[0] > 1000;
//                let amount = data[1];
//                let id;
//                let shortDescription;

//                if (isKit) {
//                    id = data[0] - 1000;
//                    shortDescription = "Kit";
//                }
//                else {
//                    id = data[0];
//                    shortDescription = "Sweetness";
//                }

//                var row = `<tr> 
//                            <td>Product, id: ${id}</td>
//                            <td>${amount}</td>
//                            <td>Price</td>
//                            <td>TotalPrice</td>
//                            <td>${shortDescription}</td>
//                            <td>Delete</td>
//                           </tr>`;

//                table.innerHTML += row;
                
//            }
//        })
//    }
//}
