var catalogoContext = {
    //#region Datos del area ParaEscolares     
    UsuarioViewModel: {},
    ArticuloVM: {},
    ResultViewModel: {},
    ArticulosVM: [],
    //#endregion  
    //////////////////////////////////////////////////////////////////////////////////////////////////METODOS PARA ASESORES
    //#region metodos...............
    getArticulos: function (datos, callbackResult) {
        var self = this;
        $.ajax({
            url: urlServer + 'Articulo/ObtenerArticulos',
            type: 'POST',
            cache: false,
            contentType: "application/json",
            data: JSON.stringify(datos)
        }).done(function (res) {
            self.ArticulosVM = res;
            if (callbackResult !== null) {
                callbackResult({ result: true, message: null });
            }
        }).fail(function (jqXHR, textStatus, errorThrown) {
            if (callbackResult !== null) {
                callbackResult({ result: false, message: "No se pudo accesar a la lista de servicios" });
            }
        });
    },

    getArticuloId: function (id, callbackResult) {
        var self = this;
        $.ajax({
            url: urlServer + 'Articulo/ObtenerArticulo/' + id,
            type: 'GET',
            cache: false,
            contentType: "application/json",
            //data: JSON.stringify(datos)
        }).done(function (res) {
            self.ArticuloVM = res;
            if (callbackResult !== null) {
                callbackResult({ result: true, message: null });
            }
        }).fail(function (jqXHR, textStatus, errorThrown) {
            if (callbackResult !== null) {
                callbackResult({ result: false, message: "No se pudo accesar a la lista de servicios" });
            }
        });
    },

    postArticulos: function (datos, callbackResult) {
        var self = this;
        $.ajax({
            url: urlServer + 'Articulo/InsertarArticulo',
            type: 'POST',
            cache: false,
            contentType: "application/json",
            data: JSON.stringify(datos)
        }).done(function (res) {
            self.ResultViewModel = res;
            if (callbackResult !== null) {
                callbackResult({ result: true, message: null });
            }
        }).fail(function (jqXHR, textStatus, errorThrown) {
            if (callbackResult !== null) {
                callbackResult({ result: false, message: "No se pudo accesar a la lista de servicios" });
            }
        });
    },

    putArticulos: function (datos, callbackResult) {
        var self = this;
        $.ajax({
            url: urlServer + 'Articulo/ModificarArticulo',
            type: 'POST',
            cache: false,
            contentType: "application/json",
            data: JSON.stringify(datos)
        }).done(function (res) {
            self.ResultViewModel = res;
            if (callbackResult !== null) {
                callbackResult({ result: true, message: null });
            }
        }).fail(function (jqXHR, textStatus, errorThrown) {
            if (callbackResult !== null) {
                callbackResult({ result: false, message: "No se pudo accesar a la lista de servicios" });
            }
        });
    },

    deleteArticulos: function (id, callbackResult) {
        var self = this;
        $.ajax({
            url: urlServer + 'Articulo/EliminarArticulo/' + id,
            type: 'DELETE',
            cache: false,
            contentType: "application/json",
        }).done(function (res) {
            self.ResultViewModel = res;
            if (callbackResult !== null) {
                callbackResult({ result: true, message: null });
            }
        }).fail(function (jqXHR, textStatus, errorThrown) {
            if (callbackResult !== null) {
                callbackResult({ result: false, message: "No se pudo accesar a la lista de servicios" });
            }
        });
    },

    //#Eendregion
};