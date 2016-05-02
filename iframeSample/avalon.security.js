
var AvalonSecurity = (function () {

    var onsuccess, onfailure, hiddenLogin;
    var _clientId = "s6BhdRkqt3";

    var setHiddenLogin = function (el) {
        that.hiddenLogin = el;
        that.hiddenLogin.load(function () {
            that.parseHash();
        });
    };

    var _openWindowWithPost = function (url, name, user, password, clientId, nonce) {



        
        var myDocument = (that.hiddenLogin.contentWindow || that.hiddenLogin.contentDocument);
        
        
            try {
                if (myDocument.document) myDocument = myDocument.document;              
            } catch (e) { window.parent.location.reload(); }
        
        

        var form = myDocument.createElement("form");
        form.setAttribute("method", "post");
        form.setAttribute("action", url);


        var input = myDocument.createElement('input');
        input.type = 'hidden';
        input.name = "username";
        input.value = user;
        form.appendChild(input);

        var input = myDocument.createElement('input');
        input.type = 'hidden';
        input.name = "password";
        input.value = password;
        form.appendChild(input);

        var input = myDocument.createElement('input');
        input.type = 'hidden';
        input.name = "clientId";
        input.value = clientId;
        form.appendChild(input);

        var input = myDocument.createElement('input');
        input.type = 'hidden';
        input.name = "nonce";
        input.value = nonce;
        form.appendChild(input);

        var input = myDocument.createElement('input');
        input.type = 'hidden';
        input.name = "response_type";
        input.value = "token";
        form.appendChild(input);

        var input = myDocument.createElement('input');
        input.type = 'hidden';
        input.name = "redirect_uri";
        input.value = that.hiddenLogin.src;
        form.appendChild(input);

        myDocument.body.appendChild(form);
        
        /*
        if (that.hiddenLogin) {
            that.hiddenLogin.contents().find('body').append(form);
        }
        else {
            alert('hidden login error');
        }*/
        // iframe.contents().find('body').append(form);
        // note I am using a post.htm page since I did not want to make
        // double request to the page
        // it might have some Page_Load call which might screw things up.
        // window.open("post.htm", name);



        form.submit();


        // document.body.removeChild(form);
    };

    var login = function (username, password) {

        var cryptoNonce = _createCryptoNonce();
        var domain = document.domain;
        if (domain.toLowerCase().indexOf('collaudo') != -1) {
            dns = "avalonuat.mps.local";
        }

        else if (domain.toLowerCase().indexOf('coding') != -1) {
            dns = "avaloncoding.mps.local";
        }
        else if (domain.toLowerCase().indexOf('cn1030') != -1) {
            dns = "avaloncoding.mps.local";
        }
        else if (domain.toLowerCase().indexOf('localhost') != -1) {
            dns = "avaloncoding.mps.local";
        }
        else if (domain.toLowerCase().indexOf('dev') != -1) {
            dns = "avaloncoding.mps.local";
        }
        else {
            dns = "avalon.mps.local";
        }
        var url = "https://" + dns + "/pri/loginUserInternetServlet"


        _openWindowWithPost(url, "_blank", username, password, _clientId, cryptoNonce)


    };

    var parseHash = function () {
        var hash = (that.hiddenLogin)[0].contentWindow.location.hash
        if (hash) {
            // Fragment exists

            var params = {}, postBody = hash.substring(1), regex = /([^&=]+)=([^&]*)/g, m;
            while (m = regex.exec(postBody)) {
                params[decodeURIComponent(m[1])] = decodeURIComponent(m[2]);
            }

            if (params.status == 'ko') {
                if (typeof (that.onfailure) !== "undefined") {
                    that.onfailure(
							{
							    errorCode: params.errorCode,
							    errorMsg: params.errorMsg,
							    nome: params.nome,
							    cognome: params.cognome
							}
							);
                    //this.onfailure(params.errorCode,params.errorMsg);
                }
            } else {

                // chiamata server per validazione nonce, token ecc...
                var nonceValidated = _validateNonce(params.nonce);
                if (nonceValidated) {
                    if (typeof (that.onsuccess) !== "undefined") {
                        that.onsuccess({
                            nome: params.nome,
                            cognome: params.cognome
                        });
                    }
                    parent.window.location = "https://" + params.dns + "/pri/login/login.action?TOKENSSO=" + params.token;
                }
            }
        } else {
            // Fragment doesn't exist
            that.hiddenLogin.document.reload();
        }
    };

    var _createCryptoNonce = function () {
        var random = _createRandomNumber();
        _setNonce(random);
        var hashValueHex;
        if (typeof (CryptoJS) !== 'undefined')
            hashValueHex = CryptoJS.SHA256(random).toString(CryptoJS.enc.Base64);
        else
            hashValueHex = random;
        return hashValueHex;
    };


    var _createRandomNumber = function () {
        var number;
        try {

            // If the client supports the more secure crypto lib
            if (Uint32Array && window.crypto && window.crypto.getRandomValues) {

                var numbers = new Uint32Array(1);
                window.crypto.getRandomValues(numbers);
                number = numbers.length ? (numbers[0] + '') : null;
            }
        } catch (e) {

            // no processing...

        } finally {

            // The fallback
            if (!number) {
                number = Math.floor(Math.random() * 1e9).toString()
						+ (new Date().getTime());
            }
        }

        return number;
    };

    var _validateNonce = function (cryptoNonce) {
        var result = false;
        var nonce;

        if (typeof (Storage) !== "undefined") {
            nonce = sessionStorage.nonce
        } else {
            nonce = window.nonce;
        }
        if (typeof (nonce) === "undefined")
            return false;
        // update data
        var hashValueHex;
        if (typeof (CryptoJS) !== 'undefined')
            hashValueHex = CryptoJS.SHA256(nonce).toString(CryptoJS.enc.Base64);
        else
            hashValueHex = nonce;
        result = (hashValueHex == cryptoNonce);
        return result;
    };

    var _setNonce = function (nonce) {
        if (typeof (Storage) !== "undefined") {
            sessionStorage.nonce = nonce;
        } else {
            window.nonce = nonce;
        }

    };

    var that = {
        onsuccess: onsuccess,
        onfailure: onfailure,
        login: login,
        setHiddenLogin: setHiddenLogin,
        parseHash: parseHash,
        hiddenLogin: hiddenLogin
    };

    return that;
})();