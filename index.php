<?php
    $displayed = "";
    $mailstatus = "";
    if (isset($_POST["mail"])) 
    {
        $email = $_POST["mail"];
        $email = filter_var($email, FILTER_SANITIZE_EMAIL);
        $email = filter_var($email, FILTER_VALIDATE_EMAIL);
        if (!$email)
        {   $displayed = 'style="display: block;"';
            $mailstatus = '<h3 style="color:red;text-align:center">Invalid Email.</h3>';
        }
        else
        {
            $to = "Saskw2010@gmail.com";
            $subject = 'From ' . $_POST["name"];
            $message = 'Name:' . $_POST["name"] . "\r\n" . 'Email:' . $email . "\r\n" . $_POST["message"];
            $message = wordwrap($message, 70, "\r\n");
            $headers = 'From: '. $email . "\r\n" .
                   'Reply-To: ' . $email . "\r\n" .
                   'X-Mailer: PHP/' . phpversion();
            if (mail($to, $subject, $message, $headers))
            {
                $displayed = 'style="display: block;"';
                $mailstatus = '<h3 style="color:green;text-align:center">Message Sent!</h3>';
            }
            else
            {
                $displayed = 'style="display: block;"';
                $mailstatus = '<h3 style="color:red;text-align:center">Something went wrong, Please try Again.</h3>';
            }
        }
    }
?>
<!DOCTYPE html>
<html lang="zxx">


<head>
    <meta charset="UTF-8">
    <meta name="description" content="">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta http-equiv="content-type" content="text/html;charset=UTF-8" />

    <!-- Title -->
    <title>WytSky</title>


    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.2.0/css/all.css" integrity="sha384-hWVjflwFxL6sNzntih27bfxkr27PmbbK/iSvJ+a4+0owXq79v+lsFkW54bOGbiDQ" crossorigin="anonymous">







    <!-- Favicon -->
    <link rel="icon" href="img/core-img/fav.png">

    <!-- Core Stylesheet -->
    <link rel="stylesheet" href="css/style.css">

    <!-- Responsive Stylesheet -->
    <link rel="stylesheet" href="css/responsive.css">


</head>

<body class="light-version">
    <!-- Preloader -->
    <div id="preloader">
        <div class="preload-content">
            <div id="dream-load"></div>
        </div>
    </div>

    <!-- ##### Header Area Start ##### -->
    <header class="header-area fadeInDown" data-wow-delay="0.2s">
        <div class="classy-nav-container light breakpoint-off">
            <div class="container">
                <!-- Classy Menu -->
                <nav class="classy-navbar light justify-content-between" id="dreamNav">

                    <!-- Logo -->
                    <a class="nav-brand light" href="#"><img src="img/core-img/logo.png" alt="logo">  </a>

                    <!-- Navbar Toggler -->
                    <div class="classy-navbar-toggler demo">
                        <span class="navbarToggler"><span></span><span></span><span></span></span>
                    </div>

                    <!-- Menu -->
                    <div class="classy-menu">

                        <!-- close btn -->
                        <div class="classycloseIcon">
                            <div class="cross-wrap"><span class="top"></span><span class="bottom"></span></div>
                        </div>

                        <!-- Nav Start -->
                        <div class="classynav">
                            <ul id="nav">
                                <li><a href="#home">Home</a></li>
                                <li><a href="#about">About</a></li>
                                <li><a href="#services">Services</a></li>
                                <li><a href="#faq">FAQ</a></li>
                                <li><a href="Pricing.php">Pricing</a></li>
                                <li><a href="#Clients">Clients</a></li>
                            </ul>

                            <!-- Button -->
                            <a href="#popup1" onclick="openForm()" class="btn login-btn ml-50">Request a Demo</a>
                        </div>
                        <!-- Nav End -->
                    </div>
                </nav>
            </div>
        </div>
    </header>
    <!-- ##### Header Area End ##### -->
    <!--popup####-->



    <div class="form-popup" id="contactFormDiv" name="contactFormDiv" <?php echo $displayed; ?> >
        <form id="contactForm" name="contactForm" action="index.php" method="post" class="form-container">
            <?php echo $mailstatus; ?> 
            <label for="Name"><b>Full Name</b></label>
            <input type="text" placeholder="Enter your name" id="name" name="name" required>

            <label for="Email"><b>Email</b></label>
            <input type="text" placeholder="Enter Email" id="mail" name="mail" required>

            <label for="Solution"><b>Solution</b></label>
            <input type="text" placeholder="Enter your requested Solution" id="message" name="message" required>

            <button type="submit" class="btn">Request</button>
            <button type="button" class="btn cancel" onclick="closeForm()">Close</button>
        </form>
    </div>
    <!-- ##### Welcome Area Start ##### -->
    <section class="hero-section blue-bg relative section-padding" id="home">

        <div class="hero-section-content">

            <div class="container h-100">
                <div class="row h-100 mb-50 align-items-center">

                    <!-- Welcome Content -->
                    <div class="col-12 col-lg-6 col-md-12">
                        <div class="welcome-content">
                            <div class="promo-section">
                                <h3 class="special-head gradient-text cyan">Business grow strategy is our mission</h3>
                            </div>
                            <h1 class="w-text wow fadeInUp" data-wow-delay="0.2s"> Simple and Powerful </h1>
                            <p class="g-text wow fadeInUp" data-wow-delay="0.3s">
                                The First artificial intelligence ERP on The Middle east
                                The Most Efficient Software To Manage using Machine Learning Concept
                                Your Business School,Commercial,Factories,Marketing and more.
                            </p>
                            <div class="dream-btn-group wow fadeInUp" data-wow-delay="0.4s">
                                <a href="#" class="btn more-btn mr-3">contact us</a>
                                <!--<a href="#" class="btn more-btn"> Learn more</a>-->
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-6 col-md-12">
                        <div class="main-ilustration main-ilustration-5"></div>
                    </div>

                </div>
            </div>
        </div>
    </section>
    <!-- ##### Welcome Area End ##### -->


    <div class="clearfix"></div>


    <section class="section-padding-0-0 relative clearfix" style="margin-top:-50px">
        <div class="container">
            <div class="has-shadow agency-sec">
                <div class="row">
                    <div class="col-lg-4 col-md-6 col-sm-12 ">
                        <div class="services-block-four v2">
                            <div class="inner-box">
                                <div class="icon-img-box">
                                    <img src="img/features/f1.svg" alt="">
                                </div>
                                <h3><a href="#">SKY (SAS)</a></h3>
                                <div class="text">Improve the accuracy and timeliness of financial plans, budgets and reports.</div>

                                <div class="side-feature-list-item v2 ">
                                    <i class="fa fa-check check-mark-icon-font" aria-hidden="true"></i>
                                    <div class="foot-c-info">Finance and Accounting</div>
                                </div>
                                <div class="side-feature-list-item v2 ">
                                    <i class="fa fa-check check-mark-icon-font" aria-hidden="true"></i>
                                    <div class="foot-c-info">Banks & Checkups Follow-up</div>
                                </div>
                                <div class="side-feature-list-item v2 ">
                                    <i class="fa fa-check check-mark-icon-font" aria-hidden="true"></i>
                                    <div class="foot-c-info">Warehouses Management</div>
                                </div>
                                <div class="side-feature-list-item v2 ">
                                    <i class="fa fa-check check-mark-icon-font" aria-hidden="true"></i>
                                    <div class="foot-c-info">Human Resource Management</div>
                                </div>
                                <div class="side-feature-list-item v2 ">
                                    <i class="fa fa-check check-mark-icon-font" aria-hidden="true"></i>
                                    <div class="foot-c-info">Manufacturing and Production</div>
                                </div>
                                <div class="side-feature-list-item v2 ">
                                    <i class="fa fa-check check-mark-icon-font" aria-hidden="true"></i>
                                    <div class="foot-c-info">Devices Maintenance Management</div>
                                </div>
                                <div class="side-feature-list-item v2 ">
                                    <i class="fa fa-check check-mark-icon-font" aria-hidden="true"></i>
                                    <div class="foot-c-info">Payroll</div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-6 col-sm-12 ">
                        <div class="services-block-four v2">
                            <div class="inner-box">
                                <div class="icon-img-box">
                                    <img src="img/features/f2.svg" alt="">
                                </div>
                                <h3><a href="#">SKY (Enterprise)</a></h3>
                                <div class="text">
                                    Enterprise resource planning manages and integrates the important parts of your business.
                                </div>
                                <div class="side-feature-list-item v2 ">
                                    <i class="fa fa-check check-mark-icon-font" aria-hidden="true"></i>
                                    <div class="foot-c-info">Sky Commercial ERP </div>
                                </div>
                                <div class="side-feature-list-item v2 ">
                                    <i class="fa fa-check check-mark-icon-font" aria-hidden="true"></i>
                                    <div class="foot-c-info">Sky e-Learning ERP</div>
                                </div>
                                <div class="side-feature-list-item v2 ">
                                    <i class="fa fa-check check-mark-icon-font" aria-hidden="true"></i>
                                    <div class="foot-c-info"> Sky Retail Solutions (Point of Sale) </div>
                                </div>
                                <div class="side-feature-list-item v2 ">
                                    <i class="fa fa-check check-mark-icon-font" aria-hidden="true"></i>
                                    <div class="foot-c-info">Sky Stock Warehousing </div>
                                </div>
                                <div class="side-feature-list-item v2 ">
                                    <i class="fa fa-check check-mark-icon-font" aria-hidden="true"></i>
                                    <div class="foot-c-info">Sky Mobilization and Data Center</div>
                                </div>
                                <div class="side-feature-list-item v2 ">
                                    <i class="fa fa-check check-mark-icon-font" aria-hidden="true"></i>
                                    <div class="foot-c-info">Sky Security Solutions </div>
                                </div>
                                <div class="side-feature-list-item v2 ">
                                    <i class="fa fa-check check-mark-icon-font" aria-hidden="true"></i>
                                    <div class="foot-c-info">Sky Web Solutions </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-6 col-sm-12 ">
                        <div class="services-block-four v2">
                            <div class="inner-box">
                                <div class="icon-img-box">
                                    <img src="img/features/f3.svg" alt="">
                                </div>
                                <h3><a href="#">SKY (Zaker)</a></h3>
                                <div class="text">
                                    Efficient Software To Manage Your School.
                                </div>
                                <div class="side-feature-list-item v2 ">
                                    <i class="fa fa-check check-mark-icon-font" aria-hidden="true"></i>
                                    <div class="foot-c-info"> Student Fees Management System </div>
                                </div>
                                <div class="side-feature-list-item v2 ">
                                    <i class="fa fa-check check-mark-icon-font" aria-hidden="true"></i>
                                    <div class="foot-c-info">Student Attendance Management System </div>
                                </div>
                                <div class="side-feature-list-item v2 ">
                                    <i class="fa fa-check check-mark-icon-font" aria-hidden="true"></i>
                                    <div class="foot-c-info">Registration System</div>
                                </div>
                                <div class="side-feature-list-item v2 ">
                                    <i class="fa fa-check check-mark-icon-font" aria-hidden="true"></i>
                                    <div class="foot-c-info">HR & Payroll System</div>
                                </div>
                                <div class="side-feature-list-item v2 ">
                                    <i class="fa fa-check check-mark-icon-font" aria-hidden="true"></i>
                                    <div class="foot-c-info">Full Customized Reporting Management System</div>
                                </div>
                                <div class="side-feature-list-item v2 ">
                                    <i class="fa fa-check check-mark-icon-font" aria-hidden="true"></i>
                                    <div class="foot-c-info">Parent mobile application</div>
                                </div>

                                <div class="side-feature-list-item v2 ">
                                    <i class="fa fa-check check-mark-icon-font" aria-hidden="true"></i>
                                    <div class="foot-c-info">Time Table Generation</div>
                                </div>
                                <div class="side-feature-list-item v2 ">
                                    <i class="fa fa-check check-mark-icon-font" aria-hidden="true"></i>
                                    <div class="foot-c-info">Student Mark</div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </section>

    <div class="clearfix"></div>

    <!-- ##### About Us Area Start ##### -->
    <section class="special section-padding-100-70 clearfix">

        <div class="container">
            <div class="row align-items-center">
                <div class="col-12 col-lg-6 offset-lg-0 col-md-12 no-padding-left">
                    <div class="welcome-meter wow fadeInUp mb-30" data-wow-delay="0.7s">
                        <img src="img/core-img/digital-5.png" alt="">
                    </div>
                </div>

                <div class="col-12 col-lg-6 offset-lg-0">
                    <div class="who-we-contant">
                        <div class="dream-dots text-left fadeInUp" data-wow-delay="0.2s" style="visibility: visible; animation-delay: 0.2s; animation-name: fadeInUp;">
                            <span class="gradient-text blue">WORKING COSELY TOGEATHER</span>
                        </div>
                        <h4 class="fadeInUp" data-wow-delay="0.3s"> Welcome to WytSky Solutions Support Center! </h4>
                        <p class="fadeInUp" data-wow-delay="0.4s">We are dedicated to making you satisfied customer and keeping it that way. This not only requires software, but a high level of continuous support from us. We provide solutions and support through an extensive global network across more than 40 subsidiaries and via our qualified international partners. In return, you are guaranteed a high level of service and availability in multiple locations and languages wherever you are, as well as continued product improvements.</p>
                        <div class="list-wrap align-items-center mb-20">
                            <div class="row">

                                <div class="col-md-6">
                                    <div class="side-feature-list-item">
                                        <i class="fa fa-check-square-o check-mark-icon-font" aria-hidden="true"></i>
                                        <div class="foot-c-info">24/7 Expert Support</div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="side-feature-list-item">
                                        <i class="fa fa-check-square-o check-mark-icon-font" aria-hidden="true"></i>
                                        <div class="foot-c-info">Managed Sucre Backups</div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="side-feature-list-item">
                                        <i class="fa fa-check-square-o check-mark-icon-font" aria-hidden="true"></i>
                                        <div class="foot-c-info">PHP 7 Ready Servers</div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="side-feature-list-item">
                                        <i class="fa fa-check-square-o check-mark-icon-font" aria-hidden="true"></i>
                                        <div class="foot-c-info">Advanced Caching</div>
                                    </div>
                                </div>

                                <div class="col-md-6">
                                    <div class="side-feature-list-item">
                                        <i class="fa fa-check-square-o check-mark-icon-font" aria-hidden="true"></i>
                                        <div class="foot-c-info">Unlimited Applications</div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="side-feature-list-item">
                                        <i class="fa fa-check-square-o check-mark-icon-font" aria-hidden="true"></i>
                                        <div class="foot-c-info">Optimized Stack</div>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </section>
    <!-- ##### About Us Area End ##### -->
    <!-- ##### About Us Area Start ##### -->
    <section class="about-us-area hero-bg section-padding-100 clearfix">
        <div class="container">
            <div class="row align-items-center">

                <div class="col-12 col-lg-6 col-sm-12">
                    <div class="who-we-contant">
                        <div class="dream-dots text-left fadeInUp" data-wow-delay="0.2s" style="visibility: visible; animation-delay: 0.2s; animation-name: fadeInUp;">
                            <span class="gradient-text cyan">CONTACT US NOW IF YOU HAVE ANY QUESTION</span>
                        </div>
                        <h4 class="w-text bold fadeInUp" data-wow-delay="0.3s">Get in Touch with us so Easy.</h4>
                        <p class="g-text fadeInUp" data-wow-delay="0.5s">
                            Contact us or someone from our Sales Team can get in touch with you.
                            Thank you for considering us.
                        </p>
                        <div class="subscribe-section has-shadow mt-30">
                            <div class="input-wrapper">
                                <i class="fa fa-home"></i>
                                <input type="email" placeholder="Enter your Email">
                            </div>
                            <button class="btn more-btn orange mt-sm-15 ml-15">subscribe</button>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </section>

    <section class=" fuel-features features section-padding-100 clearfix" id="services">

        <div class="container has-shadow">
            <div class="section-heading text-center">
                <!-- Dream Dots -->
                <div class="dream-dots justify-content-center fadeInUp" data-wow-delay="0.2s" style="visibility: visible; animation-delay: 0.2s; animation-name: fadeInUp;">
                    <span class="gradient-text blue">OUR SERVICES</span>
                </div>
                <h2 class="wow fadeInUp" data-wow-delay="0.3s" style="visibility: visible; animation-delay: 0.3s; animation-name: fadeInUp;">What we Offer</h2>
                <p class="wow fadeInUp" data-wow-delay="0.4s" style="visibility: visible; animation-delay: 0.4s; animation-name: fadeInUp;">We are professional in the ICT and AI industry of services in world. and provide the below services to clients</p>
            </div>
            <div class="row align-items-center">
                <div class="col-lg-4 col-md-6 col-sm-12 mt-md-30">
                    <div class="services-block-four v2">
                        <div class="inner-box">
                            <div class="icon-img-box">
                                <img src="img/icons/1.png" alt="">
                            </div>
                            <h3><a href="#">Investment Advise</a></h3>
                            <div class="text">
                                We are a leading advisor providing innovative and socially responsible solutions to meet clients needs,achieving superior returns for them , and to be the employer of choice.
                            </div>
                        </div>
                        <a href="#" class="icon_foot">
                            <!--<i class="fa fa-long-arrow-right"></i>-->
                        </a>
                    </div>
                    <div class="services-block-four v2">
                        <div class="inner-box">
                            <div class="icon-img-box">
                                <img src="img/icons/2.png" alt="">
                            </div>
                            <h3><a href="#">Solutions Website‎</a></h3>
                            <div class="text"> Produce the ideal reflection for your business by our creative and exclusive layouts.Created and developed with a multi programming language such as PHP , .NET</div>
                        </div>
                        <a href="#" class="icon_foot">
                            <!--<i class="fa fa-long-arrow-right"></i>-->
                        </a>
                    </div>

                </div>
                <div class="col-lg-4 col-md-6 col-sm-12 mt-md-30">
                    <div class="services-block-four v2">
                        <div class="inner-box">
                            <div class="icon-img-box">
                                <img src="img/icons/3.png" alt="">
                            </div>
                            <h3><a href="#">Technical Support</a></h3>
                            <div class="text">We provide to our clients solutions and 24/7 support through an extensive global network across more than 40 subsidiaries and via our qualified international partners.</div>
                        </div>
                        <a href="#" class="icon_foot">
                            <!--<i class="fa fa-long-arrow-right"></i>-->
                        </a>
                    </div>
                    <div class="services-block-four v2">
                        <div class="inner-box">
                            <div class="icon-img-box">
                                <img src="img/icons/4.png" alt="">
                            </div>
                            <h3><a href="#">Mobile Application</a></h3>
                            <div class="text">With the increase in use of Mobiles. Any business that wishes to survive in the market today has to build up an application that suits the requirements of its customers.</div>
                        </div>
                        <a href="#" class="icon_foot">
                            <!--<i class="fa fa-long-arrow-right"></i>-->
                        </a>
                    </div>
                </div>
                <div class="col-lg-4 col-md-6 col-sm-12 mt-md-30 mt-sm-0">
                    <div class="services-block-four v2">
                        <div class="inner-box">
                            <div class="icon-img-box">
                                <img src="img/icons/5.png" alt="">
                            </div>
                            <h3><a href="#">Hardware Services</a></h3>
                            <div class="text">
                                Experts at our hardware division are well versed in handling , assembling and troubleshooting all hardware related problems and provide security systems and Servers Solutions.
                            </div>
                        </div>
                        <a href="#" class="icon_foot">
                            <!--<i class="fa fa-long-arrow-right"></i>-->
                        </a>
                    </div>
                    <div class="services-block-four v2">
                        <div class="inner-box">
                            <div class="icon-img-box">
                                <img src="img/icons/6.png" alt="">
                            </div>
                            <h3><a href="#">Digital Marketing Services</a></h3>
                            <div class="text">Comprehensive marketing and events services, including digital marketing campaigns, social media management and brand activation's.</div>
                        </div>
                        <a href="#" class="icon_foot">
                            <!--<i class="fa fa-long-arrow-right"></i>-->
                        </a>
                    </div>
                </div>

            </div>

        </div>
    </section>

    <!-- ##### Our Services Area Start ##### -->
    <section class="section-padding-100-70 ico-about-bg relative clearfix" id="about">
        <div class="container">

            <div class="section-heading text-center">
                <!-- Dream Dots -->
                <div class="dream-dots justify-content-center fadeInUp" data-wow-delay="0.2s">
                    <span class="gradient-text blue">About US</span>
                </div>
                <h2 class="fadeInUp" data-wow-delay="0.3s"> Why Choose Us</h2>
                <p class="fadeInUp" data-wow-delay="0.4s">
                    Leader in the ICT and AI industry of services in world, a trusted partner for companies operating in the worldwide market, giving customers access to global markets and products.
                    .
                </p>
            </div>


            <div class="row">

                <div class="col-12 col-md-6 col-lg-6">
                    <!-- Content -->
                    <div class="service_single_content text-left mb-100 fadeInUp" data-wow-delay="0.2s">
                        <!-- Icon -->
                        <div class="service_icon inner-box">
                            <img src="img/icons/corporate/1.svg" alt="">

                        </div>
                        <h6>Our Mission</h6>
                        <p>
                            -  We aim to be a pioneer in providing added values for the ICT services and AI products for the benefit of our clients and accomplish new heights in service excellence with a perfect team work and become a competent market player.
                            <br />
                            - We continually wish to set new standards of work ethics, professional integrity, privacy and transparency in organizational administration, which exemplify our dedication to our objectives and to the fulfillment of our vision statement.
                            <br />
                            - We continually applied recent ICT (services, products, Tools) and AI (Artificial Intelligent-Machine learning-Big analysis) for our entire client we serve.
                            <br />
                            - We are a trusted partner that enables our clients to feel secure in the knowledge that their investment and strategic plans for ICT are complete and efficiently organized.
                            <br />
                            - Protecting the best interest of our clients and achieving their targets are our hallmarks
                            <br />
                            -  We provide investment/financial products and services to meet the needs of our clients and deliver superior returns.
                            <br />
                            - In doing so, the aspirations of our employees for growth and development are realized, and enhanced value achieved for all our stakeholders.



                        </p>
                    </div>
                </div>
                <div class="col-12 col-md-6 col-lg-6">
                    <!-- Content -->
                    <div class="service_single_content text-left mb-100 fadeInUp" data-wow-delay="0.4s">
                        <!-- Icon -->
                        <div class="service_icon">
                            <img src="img/icons/corporate/3.svg" alt="">
                        </div>
                        <h6>
                            Core Values
                        </h6>
                        <p>
                            - We are a trusted partner that enables our clients to feel secure in the knowledge that their investment and strategic plans for ICT are complete and efficiently organized.
                            <br />
                            - Protecting the best interest of our clients and achieving their targets are our hallmarks
                            <br />
                            - We provide investment/financial products and services to meet the needs of our clients and deliver superior returns.
                            <br />
                            - In doing so, the aspirations of our employees for growth and development are realized, and enhanced value achieved for all our stakeholders.
                            <br />
                            -  Independence: Freedom from the influence and special interests allow us to offer our clients honest and unbiased perspectives.
                            <br />
                            - Innovation: We relentlessly pursue new and better ways to add value to those whom we serve.
                            <br />

                            -  Investor Education: We strive to help our clients make the best and most informed investment choices.
                            <br />
                            - Our highly skilled Investment Analysts conduct research on a day-to-day basis and collaborate on ideas and advice from globally recognized financial institutions. Bourse shares this information regularly with potential and existing investors using a variety of communication channels.
                        </p>
                    </div>
                </div>

                <!--<div class="col-12 col-md-6 col-lg-6">-->
                <!-- Content -->
                <!--<div class="service_single_content text-left mb-100 fadeInUp" data-wow-delay="0.3s">-->
                <!-- Icon -->
                <!--<div class="service_icon">
                                    <img src="img/icons/corporate/2.svg" alt="">
                                </div>
                                <h6>Our Vision</h6>
                                <p>
                                    Getting AI and Machine learning deployed in all activities for every one.
                                </p>
                            </div>
                        </div>

                    </div>
                </div>-->
    </section>



    <!-- ##### About Us Area Start ##### -->
    <section class="about-us-area special section-padding-0-70 clearfix ">
        <div class="container">
            <div class="row align-items-center">

                <div class="services-column col-lg-6 col-xs-12">
                    <!--Services Block Four-->
                    <div class="services-block-four how">
                        <div class="inner-box">
                            <div class="step">1</div>
                            <h3><a class="normal" href="#">Try our products for free </a></h3>
                            <div class="text">Request a free demo and start grow Up your business with the fast and powerful solutions.</div>

                        </div>
                    </div>

                    <!--Services Block Four-->
                    <div class="services-block-four how">
                        <div class="inner-box">
                            <div class="step">2</div>
                            <h3><a class="normal" href="#">Enter your information details </a></h3>
                            <div class="text">Fill all required fields and select your prefared ERP system and solutions / Insert your prerequisites in the message box .</div>
                        </div>
                    </div>

                    <!--Services Block Four-->
                    <div class="services-block-four how" style="margin-bottom:0">
                        <div class="inner-box">
                            <div class="step">3</div>
                            <h3><a class="normal" href="#">Follow Your App usage steps</a></h3>
                            <div class="text">You can review the system user guide by viviting our <a href="https://www.youtube.com/channel/UCgSusTp6seZZYrN3er1YT1A" target="_blank">YOUTUBE</a> Channel Or Call our custmoer support .</div>
                        </div>
                    </div>

                </div>
                <div class="col-12 col-lg-6 no-padding-right">
                    <div class="welcome-meter fadeInUp" data-wow-delay="0.7s">
                        <img class="img-responsive center-block mb-30" alt="" src="img/core-img/digital-4.png">
                    </div>
                </div>

            </div>
        </div>
    </section>
    <!-- ##### About Us Area End ##### -->
    <!-- ##### FAQ & Timeline Area Start ##### -->
    <div class="faq-timeline-area section-padding-100-85" id="faq">
        <div class="container">
            <div class="section-heading text-center">
                <!-- Dream Dots -->
                <div class="dream-dots justify-content-center fadeInUp" data-wow-delay="0.2s">
                    <span class="gradient-text blue">REPEATED QUESTIONS</span>
                </div>
                <h2 class="fadeInUp" data-wow-delay="0.3s">  Frequently Questions</h2>
                <!--<p class="fadeInUp" data-wow-delay="0.4s">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed quis accumsan nisi Ut ut felis congue nisl hendrerit commodo.</p>-->
            </div>
            <div class="row align-items-center">
                <div class="col-12 col-lg-6 offset-lg-0 col-md-8 offset-md-2 col-sm-12">
                    <img src="img/core-img/digital-3.png" alt="" class="center-block img-responsive">
                </div>
                <div class="col-12 col-lg-6 col-md-12">
                    <div class="dream-faq-area mt-s ">
                        <dl style="margin-bottom:0">
                            <!-- Single FAQ Area -->
                            <dt class="v2 wave fadeInUp" data-wow-delay="0.2s">Do you charge for stopped instances?</dt>
                            <dd class="fadeInUp" data-wow-delay="0.3s">
                                <p>Yes, instances in a stopped state continue to reserve dedicated system resources (RAM, SSD storage, IP aliases, CPU) and therefore incur charges until you destroy the instance. If you wish to no longer accumulate charges for a virtual machine, please use the DESTROY button in the customer portal.</p>
                            </dd>
                            <!-- Single FAQ Area -->
                            <dt class="v2 wave fadeInUp" data-wow-delay="0.3s">
                                What payment methods do you accept?
                            </dt>
                            <dd>
                                <p>We accept Visa, Mastercard, American Express, Discover, JCB, Bitcoin (BTC and BCH), Alipay, UnionPay, WeChat Pay, and PayPal. Depending on your geographic region, Paypal supports additional payment networks, including Giropay and bank transfers.</p>
                            </dd>
                            <!-- Single FAQ Area -->
                            <dt class="v2 wave fadeInUp" data-wow-delay="0.4s">In what timezone are start and end times on my invoice?</dt>
                            <dd>
                                <p>Invoices for cloud hosting services prior to January 1st 2017 00:00 UTC represent start and end times in the United States Eastern Standard Time zone. All invoices after this date will reflect start and end times in UTC.</p>
                            </dd>
                            <!-- Single FAQ Area -->
                            <dt class="v2 wave fadeInUp" data-wow-delay="0.5s">How can I delete or retrieve the data I have with Vultr?</dt>
                            <dd>
                                <p>We've created a step by step document that shows you how to delete all your hosted data in our Vultr Docs section. Please review this guide: <a href="">YOUTUBE</a></p>
                            </dd>
                        </dl>
                    </div>
                </div>

            </div>
        </div>
    </div>
    <!-- ##### FAQ & Timeline Area End ##### -->
    <!--Tab-->
    <!-- ##### Pricing Area End ##### -->
    <!-- ##### team Area Start ##### -->
    <div class="striples-bg">
        <!-- ##### Team Area Start ##### -->
        <section class="our_team_area section-padding-100-70 clearfix" id="team">
            <div class="container">
                <div class="row">
                    <div class="col-12">
                        <div class="section-heading text-center">

                            <!-- Dream Dots -->
                            <div class="dream-dots justify-content-center fadeInUp" data-wow-delay="0.2s">
                                <span>System Support Team</span>
                            </div>
                            <h2 class="fadeInUp" data-wow-delay="0.3s">Our Awesome Instructor</h2>
                            <p class="fadeInUp" data-wow-delay="0.4s">we are provide a solo certified trainer to support our customer with new updates in our systems .</p>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <!-- Single Team Member -->
                    <div class="col-12 col-sm-6 col-lg-3">
                        <div class="our-team ico-team">
                            <div class="team_img">
                                <img src="img/team-img/member1.png" class="mt-30 width-80" alt="chef-1">
                                <!--<ul class="social">
                                    <li><a href="#"><i class="fa fa-facebook"></i></a></li>
                                    <li><a href="#"><i class="fa fa-twitter"></i></a></li>
                                    <li><a href="#"><i class="fa fa-linkedin"></i></a></li>
                                </ul>-->
                            </div>
                            <div class="team-content">
                                <h4 class="title">Randy crishen</h4>
                                <span class="post">Microsoft Certified Provider</span>
                            </div>
                        </div>
                    </div>
                    <!-- Single Team Member -->
                    <div class="col-12 col-sm-6 col-lg-3">
                        <div class="our-team ico-team">
                            <div class="team_img">
                                <img src="img/team-img/member2.png" class="mt-30 width-80" alt="chef-1">
                                <!--<ul class="social">
                                    <li><a href="#"><i class="fa fa-facebook"></i></a></li>
                                    <li><a href="#"><i class="fa fa-twitter"></i></a></li>
                                    <li><a href="#"><i class="fa fa-linkedin"></i></a></li>
                                </ul>-->
                            </div>
                            <div class="team-content">
                                <h4 class="title">Monica Ashker</h4>
                                <span class="post">SAS Certified Provider</span>
                            </div>
                        </div>
                    </div>
                    <!-- Single Team Member -->
                    <div class="col-12 col-sm-6 col-lg-3">
                        <div class="our-team ico-team">
                            <div class="team_img">
                                <img src="img/team-img/member3.png" class="mt-30 width-80" alt="chef-1">
                                <!--<ul class="social">
                                    <li><a href="#"><i class="fa fa-facebook"></i></a></li>
                                    <li><a href="#"><i class="fa fa-twitter"></i></a></li>
                                    <li><a href="#"><i class="fa fa-linkedin"></i></a></li>
                                </ul>-->
                            </div>
                            <div class="team-content">
                                <h4 class="title">Tollay Ramzomi</h4>
                                <span class="post">CCNA Certified Provider </span>
                            </div>
                        </div>
                    </div>
                    <!-- Single Team Member -->
                    <div class="col-12 col-sm-6 col-lg-3">
                        <div class="our-team ico-team">
                            <div class="team_img">
                                <img src="img/team-img/member4.png" class="mt-30 width-80" alt="chef-1">
                                <!--<ul class="social">
                                    <li><a href="#"><i class="fa fa-facebook"></i></a></li>
                                    <li><a href="#"><i class="fa fa-twitter"></i></a></li>
                                    <li><a href="#"><i class="fa fa-linkedin"></i></a></li>
                                </ul>-->
                            </div>
                            <div class="team-content">
                                <h4 class="title">Jacke Wilson</h4>
                                <span class="post">PMO Certified Privider</span>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </section>
        <!-- ##### Team Area End ##### -->
        <br /><br /><br />
        <section class="our-partners clearfix section-padding-0-70 " id="Clients">
            <div class="container">
                <div class="section-heading text-center">
                    <!-- Dream Dots -->
                    <div class="dream-dots justify-content-center fadeInUp" data-wow-delay="0.2s">
                        <span>Our Main Clients</span>
                    </div>
                    <h2 class="fadeInUp" data-wow-delay="0.3s">Our Success Partners</h2>
                    <p class="fadeInUp" data-wow-delay="0.4s">Thank you very much for keeping our product the number one brand in town. We cannot achieve this success without you as our customer. Your satisfaction is our number one concern and we promise to stay reliable.</p>
                </div>
                <div class="row">

                    <div class="col-lg-2 col-md-3 col-sm-6 col-xs-12">
                        <div class="team-member ">
                            <div class="team-img">
                                <img class="img-responsive center-block" src="img/partners/partner-1.png" alt="">
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-2 col-md-3 col-sm-6 col-xs-12">
                        <div class="team-member ">
                            <div class="team-img">
                                <img class="img-responsive center-block" src="img/partners/partner-2.png" alt="">
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-2 col-md-3 col-sm-6 col-xs-12">
                        <div class="team-member ">
                            <div class="team-img">
                                <img class="img-responsive center-block" src="img/partners/partner-3.png" alt="">
                            </div>
                        </div>
                    </div>

                    <div class="col-lg-2 col-md-3 col-sm-6 col-xs-12">
                        <div class="team-member ">
                            <div class="team-img">
                                <img class="img-responsive center-block" src="img/partners/partner-4.png" alt="">
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-2 col-md-3 col-sm-6 col-xs-12">
                        <div class="team-member ">
                            <div class="team-img">
                                <img class="img-responsive center-block" src="img/partners/partner-5.png" alt="">
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-2 col-md-3 col-sm-6   col-xs-12">
                        <div class="team-member ">
                            <div class="team-img">
                                <img class="img-responsive center-block" src="img/partners/partner-6.png" alt="">
                            </div>
                        </div>
                    </div>

                    <div class="col-lg-2 col-md-3 col-sm-6 col-xs-12">
                        <div class="team-member ">
                            <div class="team-img">
                                <img class="img-responsive center-block" src="img/partners/partner-7.png" alt="">
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-2 col-md-3 col-sm-6 col-xs-12">
                        <div class="team-member ">
                            <div class="team-img">
                                <img class="img-responsive center-block" src="img/partners/partner-8.png" alt="">
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-2 col-md-3 col-sm-6 col-xs-12">
                        <div class="team-member ">
                            <div class="team-img">
                                <img class="img-responsive center-block" src="img/partners/partner-9.png" alt="">
                            </div>
                        </div>
                    </div>

                    <div class="col-lg-2 col-md-3 col-sm-6 col-xs-12">
                        <div class="team-member ">
                            <div class="team-img">
                                <img class="img-responsive center-block" src="img/partners/partner-10.png" alt="">
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-2 col-md-3 col-sm-6 col-xs-12">
                        <div class="team-member ">
                            <div class="team-img">
                                <img class="img-responsive center-block" src="img/partners/partner-11.png" alt="">
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-2 col-md-3 col-sm-6 col-xs-12">
                        <div class="team-member ">
                            <div class="team-img">
                                <img class="img-responsive center-block" src="img/partners/partner-12.png" alt="">
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </section>
    </div>
    <!-- ##### team Area End ##### -->

    <div class="striples-bg">
        <!-- ##### Contact Info Start ##### -->
        <section class="our_contact_area section-padding-100-70 clearfix" id="contact">
            <div class="container">
                <div class="row">
                    <div class="col-12">
                        <div class="section-heading text-center">

                            <!-- Dream Dots -->
                            <div class="dream-dots justify-content-center fadeInUp" data-wow-delay="0.2s">
                                <span>Come and visit us.</span>
                            </div>
                            <h2 class="fadeInUp" data-wow-delay="0.3s">FIND US ON THE MAP !</h2>
                            <p class="fadeInUp" data-wow-delay="0.4s">
                                You can also call, message or email us.
                                We'll always be here for you!
                            </p>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <!-- Map -->
                   
                        <div class="col-12 col-lg-4 col-md-6">
                            <div class="map-wrapper">
                                <div id="map-canvas1">
                                    <iframe frameborder="0" width="100%" height="450" style="border:0" allowfullscreen="" scrolling="no" marginheight="0" marginwidth="0" src="https://www.google.com/maps/embed?pb=!1m10!1m8!1m3!1d870.921109823855!2d48.09686233640698!3d29.173969919082097!3m2!1i1024!2i768!4f13.1!5e0!3m2!1sen!2skw!4v1498746295279"></iframe>
                                </div>
                            </div>
                        </div>
                        <!-- Info -->
                      
                            <div class="col-12 col-lg-4 col-md-6">
                              

                                <p class="text-left">
                                    <span style="font:bold; color:#000000;font-weight:600">Head Office</span><br />
                                    <strong class="color-primary">Bosnia and Herzigovina </strong>

                                    <img style="width: 12% !important; display: inline;" src="img/flages/bosnia.jpg"><br>
                                    <strong>Email : </strong>  <a href="mailto:info@wytsky.net">info@wytsky.net</a><br>
                                    <strong>Mobile : </strong> <a href="tel:+358 50 354 8603">+387 62436994</a>

                                </p>
                                <hr />
                                <p class="text-left">
                                    <strong class="color-primary">Finland</strong>
                                    <img style="width: 12% !important; display: inline;" src="img/flages/435453-PEPRBX-162.jpg"><br>
                                    <strong>Email : </strong> <a href="mailto:info@wytsky.net">info@wytsky.net</a><br>
                                    <strong>Mobile : </strong> <a href="tel:+358 50 354 8603">+358 50 354 8603</a>

                                </p>
                                <hr>
                                <p class="text-left">
                                    <span style="font:bold; color:#000000;font-weight:600">Project manager Office</span><br />
                                    <strong class="color-primary">Kuwait Branch</strong>
                                    <img style="width: 12% !important; display: inline;" src="img/flages/kwt.png"><br>
                                    <strong>Email : </strong> <a href="mailto:info@wytsky.net">info@wytsky.net</a><br>
                                    <strong>Mobile : </strong> <a href="tel:+96590907209">+965-90907209</a>
                                    <br>


                                </p>
                                <hr>
                              </div>
                                    <div class="col-12 col-lg-4 col-md-6">

                                        <p class="text-left">
                                            <strong class="color-primary">Egypt Branch</strong>
                                            <img style="width: 12% !important; display: inline;" src="img/flages/eg.png"><br>
                                            <strong>Email : </strong> <a href="mailto:info@wytsky.net">info@wytsky.net</a><br>

                                            <strong>Mobile : </strong> <a href="tel:+96590907209">+965-90907209</a>

                                        </p>
                                        <hr />
                                        <p class="text-left">
                                            <strong class="color-primary">Turky Branch</strong>
                                            <img style="width: 12% !important; display: inline;" src="img/flages/turky.png"><br>
                                            <strong>Email : </strong> <a href="mailto:info@wytsky.net">info@wytsky.net</a><br>

                                            <strong>Mobile : </strong> <a href="tel:+96590907209">+965-90907209</a>

                                        </p>
                                        <hr />
                                        <p class="text-left">
                                            <strong class="color-primary">Lebanon Branch</strong>
                                            <img style="width: 12% !important; display: inline;" src="img/flages/lebanon.jpg"><br>
                                            <strong>Email : </strong> <a href="mailto:info@wytsky.net">info@wytsky.net</a><br>

                                            <strong>Mobile : </strong> <a href="tel:+96590907209">+965-90907209</a>

                                        </p>
                                        <hr>
                                    </div>
                                </div>
                                
                            </div>
    
    </section>
    </div>
    <!--Contact Info end-->
    <!-- ##### Footer Area Start ##### -->
    <footer class="footer-area bg-img">


        <div class="footer-content-area mt-0 ">
            <div class="container">
                <div class="row ">
                    <div class="col-12 col-lg-4 col-md-6">
                        <div class="footer-copywrite-info">
                            <!-- Copywrite -->
                            <div class="copywrite_text fadeInUp" data-wow-delay="0.2s">
                                <div class="footer-logo">
                                    <a href="#"><img src="img/core-img/logo.png" alt="logo">  </a>
                                </div>
                                <p>
                                    Getting AI and Machine learning deployed in all activities for every one.

                                </p>
                            </div>
                            <!-- Social Icon -->
                            <div class="footer-social-info fadeInUp" data-wow-delay="0.4s">
                                <a href="https://web.facebook.com/WytskyAI/?_rdc=1&_rdr"><i class="fa fa-facebook" aria-hidden="true"></i></a>
                                <!--<a href="#"> <i class="fa fa-twitter" aria-hidden="true"></i></a>
                                <a href="#"><i class="fa fa-google-plus" aria-hidden="true"></i></a>
                                <a href="#"><i class="fa fa-instagram" aria-hidden="true"></i></a>
                                <a href="#"><i class="fa fa-linkedin" aria-hidden="true"></i></a>-->
                            </div>
                        </div>
                    </div>

                    <div class="col-12 col-lg-4 col-md-6">
                        <div class="contact_info_area d-sm-flex justify-content-between">
                            <!-- Content Info -->
                            <div class="contact_info mt-x text-center fadeInUp" data-wow-delay="0.3s">
                                <h5>PRIVACY & TOS</h5>
                                <a href="#"><p>Advertiser Agreement</p></a>
                                <a href="#"><p>Acceptable Use Policy</p></a>
                                <a href="#"><p>Privacy Policy</p></a>
                                <a href="#"><p>Technology Privacy</p></a>
                                <a href="#"><p>Developer Agreement</p></a>
                            </div>
                        </div>
                    </div>





                    <div class="col-12 col-lg-4 col-md-6 ">
                        <div class="contact_info_area d-sm-flex justify-content-between">
                            <!-- Content Info -->
                            <div class="contact_info mt-s text-center fadeInUp" data-wow-delay="0.4s">
                                <h5>Most Popular Docs</h5>

                                <a href=""> <p>WhytSky Authorization Docs</p></a>
                                <a href=""> <p>WhytSky Authorization Tax Num</p></a>


                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </footer>
    <script>
        function openForm() {
            document.getElementById("contactFormDiv").style.display = "block";
        }

        function closeForm() {
            document.getElementById("contactFormDiv").style.display = "none";
        }
    </script>
    <!-- ##### Footer Area End ##### -->
    <!-- ########## All JS ########## -->
    <!-- jQuery js -->
    <script src="js/jquery.min.js"></script>
    <!-- Popper js -->
    <script src="js/popper.min.js"></script>
    <!-- Bootstrap js -->
    <script src="js/bootstrap.min.js"></script>
    <!-- All Plugins js -->
    <script src="js/plugins.js"></script>
    <!-- Parallax js -->
    <script src="js/dzsparallaxer.js"></script>

    <script src="js/jquery.syotimer.min.js"></script>

    <!-- script js -->
    <script src="js/script.js"></script>



</body>


</html>