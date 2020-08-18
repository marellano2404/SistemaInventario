var homeContext = {
    //#region Datos del area ParaEscolares      
    
    ResultLoginViewModel: {},
    ResulToken: {
        token: null,
        idAlumno: null,
        curp: null,
        matricula: null,
        nombreCompleto: null,
        plantel: null,
        idAdscripcion: null,
        idExpediente: null,
        idInscripcion: null,
        estatus:null,
        semestre: null,
        grupo: null,
        turno: null,
        expires: null
    },
    Usuarioview: {
        Username: null,
        Password: null
    },
    //#endregion
    autenticarUsuario: function (Usuarioview, callbackResult) {
        var self = this;
        $.ajax({
            url: urlPortal + 'Home/AutentificarUser',
            type: 'POST',
            cache: false,
            contentType: "application/json",
            data: JSON.stringify(Usuarioview)
        }).done(function (res) {
            self.ResultLoginViewModel = res;
            if (callbackResult !== null) {
                callbackResult({ result: true, message: null });
            }
        }).fail(function (jqXHR, textStatus, errorThrown) {
            if (callbackResult !== null) {
                callbackResult({ result: false, message: "No se pudo accesar a la lista de servicios" });
            }
        });
    },  
    registrarHistorial: function (opcion, idalumno, detalles, callbackResult) {
        var self = this;
        $.ajax({
            url: urlServer + 'Seguridad/RegistrarHistorialAlumno',
            type: 'Get',
            cache: false,
            contentType: "application/json",
            data: { "Opcion": opcion, "IdUser": idalumno, "Detalles": detalles }
        }).done(function (res) {
            if (callbackResult !== null) {
                callbackResult({ result: true, message: null });
            }
        }).fail(function (jqXHR, textStatus, errorThrown) {
            if (callbackResult !== null) {
                callbackResult({ result: false, message: "No se pudo accesar a la lista de servicios" });
            }
        });
    },
    getDatosopenPay: function (opcion, idaspirante, ceneval, callbackResult) {
        var self = this;
        $.ajax({
            url: urlServer + 'OpenPay/GetDatosOpenpay',
            type: 'GET',
            cache: false,
            contentType: "application/json",
            data: { "Opcion": opcion, "IdSustentante": idaspirante, "Ceneval": ceneval }
        }).done(function (res) {
            self.DatosReferenciaPago = res;
            if (callbackResult !== null) {
                callbackResult({ result: true, message: null });
            }
        }).fail(function (jqXHR, textStatus, errorThrown) {
            if (callbackResult !== null) {
                callbackResult({ result: false, message: "No se pudo accesar a la lista de servicios" });
            }
        });
    },
    getRecibospagoopenPay: function (IdSustentante, callbackResult) {
        var self = this;
        $.ajax({
            url: urlServer + 'OpenPay/GetRecibosPagoOpenpay',
            type: 'POST',
            cache: false,
            contentType: "application/json",
            data: JSON.stringify(IdSustentante)
        }).done(function (res) {
            self.RecibosOpenPayViewModel = res;
            if (callbackResult !== null) {
                callbackResult({ result: true, message: null });
            }
        }).fail(function (jqXHR, textStatus, errorThrown) {
            if (callbackResult !== null) {
                callbackResult({ result: false, message: "No se pudo accesar a la lista de servicios" });
            }
        });
    },
    putVerificarRecibo: function (IdCliente, callbackResult) {
        var self = this;
        $.ajax({
            url: urlServer + 'OpenPay/GetVerificarCargoIndividual',
            type: 'POST',
            cache: false,
            contentType: "application/json",
            data: JSON.stringify(IdCliente)
        }).done(function (res) {
            if (res == true) {
                if (callbackResult !== null) {
                    callbackResult({ result: true, message: null });
                }
            }
            if (res == false) {
                if (callbackResult !== null) {
                    callbackResult({ result: false, message: null });
                }
            }
        }).fail(function (jqXHR, textStatus, errorThrown) {
            if (callbackResult !== null) {
                callbackResult({ result: false, message: null });
            }
        });
    },
    //////////////////////////////////////////////////////////////////////////////////////////////////METODOS PARA ASESORES  
    //#region asesores

    //#endregion
};