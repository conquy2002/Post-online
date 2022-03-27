var fetchurl =  {
    get:  (url, callback) => {
        var resolveFunc = function(){};
        var rejectFunc = function(){};
        var returnPromise = new Promise(function (resolve, reject) {
            resolveFunc = resolve;
            rejectFunc = reject;
        });
        if (!callback) {
            callback = function (err, friendList) {
                if (err) {
                return rejectFunc(err);
                }
                resolveFunc(friendList);
            };
        }
        fetch(url,{
            method : "GET",
        })
        .then(response => response.json())
        .then(data => callback(null,data))
        .catch(function(error) {
            callback(error)
        })
        return returnPromise
    },

    post: (url, data= { }, file ,callback) => fetch(url,{
        method: 'POST',
        headers: file ? {} : {'Content-type': 'application/json; charset=UTF-8'},
        body: file ? data : JSON.stringify(data)
    })
    .then(response => response.json())
    .then(data => callback(null,data))
    .catch(function(error) {
        callback(error)
    }),

    put: (url,data ={},callback) => fetch(url, {
        method: 'PUT',
        headers: {
            'Content-type': 'application/json; charset=UTF-8' // Indicates the content
        },
        body: JSON.stringify(data)
    }).then(response => response.json())
    .then(data => callback(null,data))
    .catch(function(error) {
        callback(error)
    }),
    delete:  (url, callback) => fetch(url,{
        method : "DELETE",
    })
    .then(response => response.json())
    .then(data => callback(null,data))
    .catch(function(error) {
        callback(error)
    })
};

function setCookie(cname,cvalue,exdays) {
    const d = new Date();
    d.setTime(d.getTime() + (exdays*24*60*60*1000));
    let expires = "expires=" + d.toUTCString();
    document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
};

function getCookie(cname) {
    let name = cname + "=";
    let decodedCookie = decodeURIComponent(document.cookie);
    let ca = decodedCookie.split(';');
    for(let i = 0; i < ca.length; i++) {
      let c = ca[i];
      while (c.charAt(0) == ' ') {
        c = c.substring(1);
      }
      if (c.indexOf(name) == 0) {
        return c.substring(name.length, c.length);
      }
    }
    return "";
};

var UrlApi = "https://localhost:7193/api";
var UrlLogin = "/Login";
var UrlUser = "/Users";
var UrlImagerName = '/Imager?name=';


