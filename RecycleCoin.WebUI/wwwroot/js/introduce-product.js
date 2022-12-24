    function send_photo() {
        Webcam.snap(function (data_uri) {
            var raw_image_data = data_uri.replace(/^data\:image\/\w+\;base64\,/, '');

            document.getElementById('detectedObject_DetectedImageBase64').value = raw_image_data;
            document.getElementById('myform').submit();
        })
    }
    function set_photoindex() {
        document.getElementById('detectedObject_ObjectIndex').value = -1;
    }
    function submit_form() {
        document.getElementById('myform').submit();
    }
    function go_to_set_recycle() {
        document.getElementById('myform').setAttribute("action", "/Operator/SetRecycleToUser")
        document.getElementById('myform').submit();
    }
