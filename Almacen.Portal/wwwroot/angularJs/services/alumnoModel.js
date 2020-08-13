var alumnoContext = {
    //#region Datos del area ParaEscolares 
    alumno: {
        nombres: null,
        apellidopaterno: null,
        apellidomaterno: null,
        fechanacimiento: null,
        sexo: null,
        entidadnacimiento: null
    },
    UsuarioViewModel: {},
    Datosalumno: {
        IdAlumno: null,
        Correo: null,
        NumCelular: null,
        NumCasa: null       
    },
    //#endregion  
    //////////////////////////////////////////////////////////////////////////////////////////////////METODOS PARA ASESORES
    //#region metodos...............
    CerrarSesion: function (callbackResult) {
        $.ajax({
            url: urlPortal + 'Home/CerrarSesion',
            type: 'GET',
            cache: false,
            contentType: "application/json"
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
    autenticarAspiranteRegistro: function (Usuarioview, callbackResult) {
        var self = this; 
        $.ajax({
            url: urlServer + 'CenevalAspirante/AutenticarAspirante',
            type: 'POST',
            cache: false,
            contentType: "application/json",
            data: JSON.stringify(Usuarioview)
        }).done(function (res) {
            self.UsuarioViewModel = res;
            if (callbackResult !== null) {
                callbackResult({ result: true, message: null });
            }
        }).fail(function (jqXHR, textStatus, errorThrown) {
            if (callbackResult !== null) {
                callbackResult({ result: false, message: "No se pudo accesar a la lista de servicios" });
            }
        });
    },
    getDatosAspirante: function (Opcion,Id,Ceneval,callbackResult) {
        var self = this;
        $.ajax({
            url: urlServer + 'CenevalAspirante/GetDatosAspirante',
            type: 'GET',
            cache: false,
            contentType: "application/json",
            data: { "Opcion": Opcion, "Id": Id, "Ceneval": Ceneval}
        }).done(function (res) {
            self.AspiranteDatosViewModel = res;
            if (callbackResult !== null) {
                callbackResult({ result: true, message: null });
            }
        }).fail(function (jqXHR, textStatus, errorThrown) {
            if (callbackResult !== null) {
                callbackResult({ result: false, message: "No se pudo accesar a la lista de servicios" });
            }
        });
    },
    verificaDatosAlumno: function (Idalumno, callbackResult) {
        $.ajax({
            url: urlServer + 'Alumnos/VerificarDatoAlumno',
            type: 'POST',
            cache: false,
            contentType: "application/json",
            data: JSON.stringify(Idalumno)
        }).done(function (res) {
            if (res == true) {
                if (callbackResult !== null) {
                    callbackResult({ result: true, message: null });
                }
            }
            else {
                if (callbackResult !== null) {
                    callbackResult({ result: false, message: null });
                }
            }
            
        }).fail(function (jqXHR, textStatus, errorThrown) {
            if (callbackResult !== null) {
                callbackResult({ result: false, message: "No se pudo accesar a la lista de servicios" });
            }
        });
    },
    guardarDatosEntrada: function (Datosalumno, callbackResult) {
        $.ajax({
            url: urlServer + 'Alumnos/GuardarDatosEntrada',
            type: 'POST',
            cache: false,
            contentType: "application/json",
            data: JSON.stringify(Datosalumno)
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
    //#endregion
    //#region  Metodos de Partial User
    actualizarCorreo: function (Iduser,Correo, callbackResult) {
        var self = this;
        $.ajax({
            url: urlServer + 'CenevalAspirante/ModificarCorreo',
            type: 'GET',
            cache: false,
            contentType: "application/json",
            data: { "IdUser": Iduser, "Correo": Correo }
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
    //#endregion
    //#region METODO DE PAGO
    enviarPago: function (UsuarioView,callbackResult) {
        var self = this;
        $.ajax({
            url: urlServer + 'OpenPay/GetPagoTienda',
            type: 'POST',
            cache: false,
            contentType: "application/json",
            data: JSON.stringify(UsuarioView)
        }).done(function (res) {
            self.PagoTiendaViewModel = res;
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

    //#region OBTIENE DATOS DE LA FICHA
    ObtenerDatoFicha: function (IdSustentante, callbackResult) {
        var self = this;
        $.ajax({
            url: urlServer + 'CenevalAspirante/GetDatosFichaAspirante',
            type: 'GET',
            cache: false,
            contentType: "application/json",
            //data: JSON.stringify(IdSustentante)
            data: { "IdSustentante": IdSustentante }
        }).done(function (res) {
            self.DatosFichaAspiranteViewModel = res;
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