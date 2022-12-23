/*jslint node: true */
"use strict";
var soap = require("soap");
var express = require("express");
var fs = require("fs");

// Coin'i belirtilen adrese belirtilen miktarda yolla
function coinTransferFunction(args) {
  const { exec, execSync } = require("child_process");
  var cmdString =
    "recylecoind sendtoaddress " + args.address + " " + args.coinAmount;
  try {
    var result = execSync(cmdString);

    var rs = result.toString();
    console.log(`stdout: ${result}`);
    return {
      result: rs.slice(0, rs.length - 2)
    }


  }
  catch (err) {
    //console.log("output", err)
    console.log("sdterr", err.stderr.toString())
    return {
      result: err.stderr.toString()
    }
  }

}
// Object Detection Service
var serviceObject = {
  CoinTransferService: {
    CoinTransferServiceSoapPort: {
      CoinTransfer: coinTransferFunction,
    },
    CoinTransferSoap12Port: {
      CoinTransfer: coinTransferFunction,
    },
  },
};

// load the WSDL file
var xml = fs.readFileSync("service.wsdl", "utf8");
// create express app
var app = express();
// Launch the server and listen
var port = 7335;

app.listen(port, function () {
  console.log("Listening on port " + port);
  var wsdl_path = "/wsdl";
  soap.listen(app, wsdl_path, serviceObject, xml);
  console.log(
    "Check http://localhost:" +
    port +
    wsdl_path +
    "?wsdl to see if the service is working"
  );
});
