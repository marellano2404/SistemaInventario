var homeContext = {
    //#region Datos del area ParaEscolares      
    Turno: [
        { Descripcion: 'Mat.', ClaveTurno: 'M', },
        { Descripcion: 'Vesp.', ClaveTurno: 'V', },
        { Descripcion: 'Mixto.', ClaveTurno: 'X', },
        { Descripcion: 'Ambos.', ClaveTurno: 'A', },
    ],
    Semestres: [
        { Descripcion: '1er. Semestre', IdSemestre: '1', },
        { Descripcion: '2do. Semestre', IdSemestre: '2', },
        { Descripcion: '3er. Semestre', IdSemestre: '3', },
        { Descripcion: '4to. Semestre', IdSemestre: '4', },
        { Descripcion: '5to. Semestre', IdSemestre: '5', },
        { Descripcion: '6to. Semestre', IdSemestre: '6', },
    ],
    ListaPeriodos: [
        { Descripcion: 'Mat.', ClaveTurno: 'M', },
        { Descripcion: 'Vesp.', ClaveTurno: 'V', },
    ],
    ListaSexo: [
        { Descripcion: 'Hombre', Clave: 'H', },
        { Descripcion: 'Mujer', Clave: 'M', },
    ],
    ResultLoginViewModel: {
        exito: null,
        mensaje: null
    },
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
    UsuarioViewModel: {
        idAlumno: null,
        idExpediente: null,
        matricula: null
    },
    Usuarioview: {
        Curp: null,
        Matricula: null
    },
    DatosReferenciaPago: {
        id_Cliente: null,
        monto: null,
        status: null,
        fecha_Creacion: null,
        order_Id: null,
        metodo: null,
        referencia_pago: null,
        activo: null,
        fecha_vencimiento: null
    },
    RecibosOpenPayViewModel: {
        id_Cliente: null,
        monto: null,
        status: null,
        fecha_Creacion: null,
        order_Id: null,
        metodo: null,
        referencia_pago: null,
        activo: null
    },
    PagoBancoViewModel: {
        id: null,
        description: null,
        authorization: null,
        amount: null,
        operation_type: null,
        payment_method: null,
        type: null,
        reference: null,
        barcode_url: null,
        order_id: null,
        transaction_type: null,
        creation_date: null,
        currency: null,
        status: null,
        method: null
    },
    //#endregion
    autenticarAlumno: function (Usuarioview, callbackResult) {
        var self = this;
        $.ajax({
            url: urlServer + 'Seguridad/AutenticarAlumno',
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
    getDatosAlumno: function (Usuarioview, callbackResult) {
        var self = this;
        $.ajax({
            url: urlPortal + 'Home/CrearToken',
            type: 'POST',
            cache: false,
            contentType: "application/json",
            data: JSON.stringify(Usuarioview)
        }).done(function (res) {
            self.ResulToken = res;
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