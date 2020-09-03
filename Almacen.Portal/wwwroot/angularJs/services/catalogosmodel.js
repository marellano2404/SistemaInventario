var catalogoContext = {
    //#region Datos del area ParaEscolares     
    UsuarioViewModel: {},
    articuloVM: {},
    ResultViewModel: {},
    ArticulosVM: [],
    TipoMedicamentos:
    [
        { id: 1, descripcion: "Libre Acceso" },
        { id: 2, descripcion: "Controlados"},
        { id: 3, descripcion: "Con Receta" }
        ],
    laboratoriosVM: [],
    tipoUnidadesVM: [],
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
            self.articuloVM = res;
            if (callbackResult !== null) {
                callbackResult({ result: true, message: null });
            }
        }).fail(function (jqXHR, textStatus, errorThrown) {
            if (callbackResult !== null) {
                callbackResult({ result: false, message: "No se pudo accesar a la lista de servicios" });
            }
        });
    },

    getLaboratorios: function (callbackResult) {
        var self = this;
        $.ajax({
            url: urlServer + 'Laboratorio/ObtenerLaboratorios',
            type: 'GET',
            cache: false,
            contentType: "application/json"
        }).done(function (res) {
            self.laboratoriosVM = res;
            if (callbackResult !== null) {
                callbackResult({ result: true, message: null });
            }
        }).fail(function (jqXHR, textStatus, errorThrown) {
            if (callbackResult !== null) {
                callbackResult({ result: false, message: "No se pudo accesar a la lista de servicios" });
            }
        });
    },
    getTipoUnidades: function (callbackResult) {
        var self = this;
        $.ajax({
            url: urlServer + 'TipoUnidades/ObtenerTipoUnidades',
            type: 'GET',
            cache: false,
            contentType: "application/json"
        }).done(function (res) {
            self.tipoUnidadesVM = res;
            if (callbackResult !== null) {
                callbackResult({ result: true, message: null });
            }
        }).fail(function (jqXHR, textStatus, errorThrown) {
            if (callbackResult !== null) {
                callbackResult({ result: false, message: "No se pudo accesar a la lista de servicios" });
            }
        });
    },

    postArticulos: function (datoArticulo, callbackResult) {
        var self = this;
        $.ajax({
            url: urlServer + 'Articulo/InsertarArticulo',
            type: 'POST',
            cache: false,
            contentType: "application/json",
            data: JSON.stringify(datoArticulo)
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

    putArticulos: function (datoArticulo, callbackResult) {
        var self = this;
        $.ajax({
            url: urlServer + 'Articulo/ModificarArticulo',
            type: 'POST',
            cache: false,
            contentType: "application/json",
            data: JSON.stringify(datoArticulo)
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