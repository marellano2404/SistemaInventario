var almacenContext = {
    //#region Datos del area ParaEscolares     
    UsuarioViewModel: {},
    salidasAlmacenVM: [],
    DetalleSalidaVM:[],
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
    getdetalleSalidaAlmacen: function (FolioSalidaAlmacen,callbackResult) {
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
    }
    //#endregion
};