var urlServer = "https://localhost:44397/api/";
var urlPortal = "/";
//var urlServer = "http://marellano-002-site2.etempurl.com/";
//var urlPortal = "/sicecesba/";
//var urlserver = "http://" + window.location.hostname + ":84/api/";
//var urlportal = "/aspirantescobach/";
var itemsPorPagina = 10;
function obtenerToken() {
    /// <signature>
    /// <summary>Devuelve el token del usuario autenticado.</summary>
    /// </signature>
    var tokenItem = sessionStorage.getItem("user");
    if (tokenItem !== null) {
        return "Bearer " + angular.fromJson(tokenItem).token;
    } else {
        return null;
    }
}

function guid() {
    /// <signature>
    /// <summary>Devuelve un nuevo GUID.</summary>
    /// </signature>
    return s4() + s4() + '-' + s4() + '-' + s4() + '-' +
        s4() + '-' + s4() + s4() + s4();
}

function s4() {
    return Math.floor((1 + Math.random()) * 0x10000)
        .toString(16)
        .substring(1);
}


