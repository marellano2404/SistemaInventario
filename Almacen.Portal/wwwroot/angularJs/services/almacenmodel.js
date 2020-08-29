var almacenContext = {
    //#region Datos del area ParaEscolares     
    UsuarioViewModel: {},
    salidasAlmacenVM: [],
    DetalleSalidaVM: [],
    ResultViewModel: {},
    ArticuloInventarioVM: {},
    ArticuloSalidaSel:
    {
        idSalidaAlmacen: null,
        idInventario: null,
        idArticulo: null,
        tipoUnidad: null,
        cantidadSalida:null
    },
    ListaUnidades:
    [
        { Valor: 'PIEZA', Id: 1 },
        { Valor: 'CAJA', Id: 2 },
        { Valor: 'KIT', Id: 3 }
    ],
    //#endregion  
    //////////////////////////////////////////////////////////////////////////////////////////////////METODOS PARA ASESORES
    //#region metodos................
    getSalidasAlmacen: function (Estado, callbackResult) {
        var self = this;
        $.ajax({
            url: urlServer + 'SalidasAlmacen/GetSalidasAlmacen',
            type: 'POST',
            cache: false,
            contentType: "application/json",
            data: JSON.stringify(Estado)
        }).done(function (res) {
            self.salidasAlmacenVM = res;
            if (callbackResult !== null) {
                callbackResult({ result: true, message: null });
            }
        }).fail(function (jqXHR, textStatus, errorThrown) {
            if (callbackResult !== null) {
                callbackResult({ result: false, message: "No se pudo accesar a la lista de servicios" });
            }
        });
    },
    getdetalleSalidaAlmacen: function (FolioSalidaAlmacen, callbackResult) {
        var self = this;
        $.ajax({
            url: urlServer + 'SalidasAlmacen/GetDetalleSalidasAlmacen',
            type: 'POST',
            cache: false,
            contentType: "application/json",
            data: JSON.stringify(FolioSalidaAlmacen)
        }).done(function (res) {
            self.DetalleSalidaVM = res;
            if (callbackResult !== null) {
                callbackResult({ result: true, message: null });
            }
        }).fail(function (jqXHR, textStatus, errorThrown) {
            if (callbackResult !== null) {
                callbackResult({ result: false, message: "No se pudo accesar a la lista de servicios" });
            }
        });
    },
    buscarArticuloInvetario: function (Tipo,Valor,callbackResult) {
        var self = this;
        $.ajax({
            url: urlServer + 'SalidasAlmacen/BuscarArticuloInventario',
            type: 'GET',
            cache: false,
            contentType: "application/json",
            data: {"Tipo":Tipo, "Valor": Valor}
        }).done(function (res) {
            self.ArticuloInventarioVM = res;
            if (callbackResult !== null) {
                callbackResult({ result: true, message: null });
            }
        }).fail(function (jqXHR, textStatus, errorThrown) {
            if (callbackResult !== null) {
                callbackResult({ result: false, message: "No se pudo accesar a la lista de servicios" });
            }
        });
    },
    borrardetalleSalidaAlmacen: function (IdDetalleSalidaAlmacen, callbackResult) {
        var self = this;
        $.ajax({
            url: urlServer + 'SalidasAlmacen/EliminarDetalleSalidasAlmacen',
            type: 'POST',
            cache: false,
            contentType: "application/json",
            data: JSON.stringify(IdDetalleSalidaAlmacen)
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
    putartSalidaAlmacen: function (ArticuloSalidaAlmacen,callbackResult) {
        var self = this;
        $.ajax({
            url: urlServer + 'SalidasAlmacen/PutArticuloSalidaAlmacen',
            type: 'POST',
            cache: false,
            contentType: "application/json",
            data: JSON.stringify(ArticuloSalidaAlmacen)
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
    //#endregion
};