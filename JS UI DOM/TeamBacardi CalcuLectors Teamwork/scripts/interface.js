window.addEventListener('load', function() {
    $('#gameScreen').hide();
    var selectBackground = false;
    var selectHero = false;
    toggleDarkImg('.backgroungImgHolder');
    toggleDarkImg('.select');


    $('#backgrounds').on('click', '.backgroungImgHolder', function() {
        let $this = $(this),
            info = $this.data('info');


        $('.backgroungImgHolder').each(function() {
            $(this).removeClass('border');
        });

        $(this).addClass('border');
        backGroundImage = document.getElementById('background' + info);
        selectBackground = true;

    });

    $('.select').on('click', function() {
        let $this = $(this),
            id = this.id;
        if (id === "cyki") {
            fallingNumberProperties = cykiProperties;
        }
        if (id === "koce") {
            fallingNumberProperties = koceProperties;
        }
        if (id === "doncho") {
            fallingNumberProperties = donchoProperties;
        }
        $('.select').each(function() {
            $(this).removeClass('border');
        });
        $this.addClass('border');

        heroProperties.image = document.getElementById(this.id + 'Image');
        selectHero = true;

        $('.selected').removeClass('selected');
        $this.addClass('selected');


    });

    $('.select').hover(function() {
        $('.selected').prev().children().hide();
        $('.selected').next().children().hide();
        $(this).prev().children().show();
        $(this).next().children().show();
    }, function() {

        $(this).prev().children().hide();
        $(this).next().children().hide();
        $('.selected').prev().children().show();
        $('.selected').next().children().show();

    });

    function toggleDarkImg(selector) {
        $(selector).hover(function() {
                $(this).addClass('darken');
            },
            function() {
                $(this).removeClass('darken');
            }
        );
    }

    $('#changeplayerbtn').on('click', function() {
        $('#gameScreen').hide();
        $('#gameOver').hide();
        $('#menu').show();
        defaultProperties();
    });

    $('#playagainbtn').on('click', function() {
        $('#gameScreen').hide();
        $('#gameOver').hide();
        defaultProperties();
        Start();
    });

    $('#playbtn').on('click', function() {
        if (selectBackground && selectHero) {
            Start();
        } else {
            alert('Choose background and hero first!');
        }
    });

    function defaultProperties() {
        gravitySpeed = 1;
        spawns = 0;
        spawnTimesPerLevel = 10;
    }
});