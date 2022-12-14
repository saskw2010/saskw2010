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
    <title>
        Our Prices


    </title>


    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.2.0/css/all.css" integrity="sha384-hWVjflwFxL6sNzntih27bfxkr27PmbbK/iSvJ+a4+0owXq79v+lsFkW54bOGbiDQ" crossorigin="anonymous">



    <!-- Favicon -->
    <link rel="icon" href="img/core-img/favicon.png">

    <!-- Core Stylesheet -->
    <link rel="stylesheet" href="css/style.css">

    <!-- Responsive Stylesheet -->
    <link rel="stylesheet" href="css/responsive.css">
    <!--font awesome styles-->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">


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
                                <li><a href="index.php">Home</a></li>
                                <li><a href="index.php">About</a></li>
                                <li><a href="index.php">Services</a></li>
                                <li><a href="index.php">FAQ</a></li>
                                <li><a href="index.php">Pricing</a></li>
                                <li><a href="index.php#Clients">Clients</a></li>
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
        <form id="contactForm" name="contactForm" action="Pricing.php" method="post" class="form-container">
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
    <!-- ###Price  Area Start ##### -->
    <div class="striples-bg">
        <section class="our_team_area section-padding-100-70 clearfix">

            <div class="col-12">
                <div class="section-heading text-center">

                    <!-- Dream Dots -->
                    <div class="dream-dots justify-content-center fadeInUp" data-wow-delay="0.2s">
                        <span>Our Pricies </span>
                    </div>
                    <h2 class="fadeInUp" data-wow-delay="0.3s">Our Awesome Price Planning</h2>
                    <p class="fadeInUp" data-wow-delay="0.4s">
                        We strive to be competitive in our pricing guidelines. For the most up to date pricing and rate schedules, please call our friendly customer service.
                    </p>
                </div>
            </div>


            <div class="comparison table-responsive">


                <table>
                    <thead>

                        <tr>
                            <th style="font-weight:bold ; font-size:26px;">SKY Solution</th>
                            <!--<th class="price-info">

                                <div class="pricingTable6 White text-center single_price_table_conten wow fadeInUp" data-wow-delay="0.2s" style="visibility: visible; animation-delay: 0.2s; animation-name: fadeInUp;">
                                    <h3 class="title">SKY (SAS)</h3>
                                    <div class="price-value">
                                        $10.00
                                        <span class="month">/month</span>
                                    </div>
                                    <ul class="pricing-content">
                                        <li>50GB Disk Space</li>
                                        <li>50 Email Accounts</li>
                                        <li>50GB Monthly Bandwidth</li>
                                        <li class="disable"><i class="fa fa-times"></i></li>
                                        <li class="disable"><i class="fa fa-times"></i></li>
                                    </ul>
                                    <a href="#" class="pricingTable-signup">Sign up</a>

                                </div>

                            </th>-->
                            <th class="price-info">
                                <div class="pricingTable6  single_price_table_conten  text-center wow fadeIn" data-wow-delay="0.3s" style="visibility: visible; animation-delay: 0.3s; animation-name: fadeIn;">

                                    <h3 class="title">SAS</h3>
                                    <div class="price-value">
                                        $20.00
                                        <span class="month">/month</span>
                                    </div>
                                    <ul class="pricing-content">
                                        <li>60GB Disk Space</li>
                                        <li>60 Email Accounts</li>
                                        <li>60GB Monthly Bandwidth</li>
                                        <li>15 Subdomains</li>
                                        <li class="disable"><i class="fa fa-times"></i></li>
                                    </ul>
                                    <a href="#"  onclick="openForm()"  class="pricingTable-signup">Sign up</a>
                                </div>

                            </th>
                            <th class="price-info">
                                <div class="pricingTable6 blue ingle_price_table_conten text-center wow fadeInUp" data-wow-delay="0.4s" style="visibility: visible; animation-delay: 0.4s; animation-name: fadeInUp;">

                                    <h3 class="title">Interprise</h3>
                                    <div class="price-value">
                                        $30.00
                                        <span class="month">/month</span>
                                    </div>
                                    <ul class="pricing-content">
                                        <li>70GB Disk Space</li>
                                        <li>70 Email Accounts</li>
                                        <li>70GB Monthly Bandwidth</li>
                                        <li>20 Subdomains</li>
                                        <li>25 Domains</li>
                                    </ul>
                                    <a href="#"  onclick="openForm()" class="pricingTable-signup">Sign up</a>
                                </div>
                            </th>
                            <th class="price-info">
                                <div class="pricingTable6 green ingle_price_table_conten text-center wow fadeInUp" data-wow-delay="0.4s" style="visibility: visible; animation-delay: 0.4s; animation-name: fadeInUp;">

                                    <h3 class="title">Zaker</h3>
                                    <div class="price-value">
                                        $30.00
                                        <span class="month">/month</span>
                                    </div>
                                    <ul class="pricing-content">
                                        <li>70GB Disk Space</li>
                                        <li>70 Email Accounts</li>
                                        <li>70GB Monthly Bandwidth</li>
                                        <li>20 Subdomains</li>
                                        <li>25 Domains</li>
                                    </ul>
                                    <a href="#"   onclick="openForm()" class="pricingTable-signup">Sign up</a>
                                </div>
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td></td>
                            <td colspan="3">Seperate business from personal spending</td>
                        </tr>
                        <tr class="compare-row">
                            <td>Seperate business/personal</td>
                            <td><span class="tickorange">✔</span></td>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td colspan="3">Estimate tax payments</td>
                        </tr>
                        <tr>
                            <td>Estimate tax payments</td>
                            <td><span class="tickorange">✔</span></td>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td colspan="3">Track deductible mileage</td>
                        </tr>
                        <tr class="compare-row">
                            <td>Track deductible mileage</td>
                            <td><span class="tickorange">✔</span></td>
                            <td></td>
                            <td></td>

                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td colspan="3">Download online banking</td>
                        </tr>
                        <tr>
                            <td>Download online banking</td>
                            <td><span class="tickorange">✔</span></td>
                            <td><span class="tickblue">✔</span></td>
                            <td><span class="tickgreen">✔</span></td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td colspan="3">Works on PC, Mac & mobile</td>
                        </tr>
                        <tr class="compare-row">
                            <td>Multi-device</td>
                            <td><span class="tickorange">✔</span></td>
                            <td><span class="tickblue">✔</span></td>
                            <td><span class="tickgreen">✔</span></td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td colspan="3">Create invoices & estimates</td>
                        </tr>
                        <tr>
                            <td>Create invoices & estimates</td>
                            <td><span class="tickorange">✔</span></td>
                            <td><span class="tickblue">✔</span></td>
                            <td><span class="tickgreen">✔</span></td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td colspan="3">Manage VAT</td>
                        </tr>
                        <tr class="compare-row">
                            <td>Manage VAT</td>
                            <td></td>
                            <td><span class="tickblue">✔</span></td>
                            <td><span class="tickgreen">✔</span></td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td colspan="3">Run payroll</td>
                        </tr>
                        <tr>
                            <td>Run payroll</td>
                            <td></td>
                            <td><span class="tickblue">✔</span></td>
                            <td><span class="tickgreen">✔</span></td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td colspan="3">Number of users</td>
                        </tr>
                        <tr class="compare-row">
                            <td>Number of users</td>
                            <td class="tickorange">1 user</td>
                            <td class="tickblue">3 user</td>
                            <td class="tickgreen">5 user</td>

                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td colspan="3">Manage bills & payments</td>
                        </tr>
                        <tr>
                            <td>Manage bills & payments</td>
                            <td></td>
                            <td></td>
                            <td><span class="tickgreen">✔</span></td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td colspan="3">Handle multiple currencies</td>
                        </tr>
                        <tr class="compare-row">
                            <td>Handle multiple currencies</td>
                            <td></td>
                            <td></td>
                            <td><span class="tickgreen">✔</span></td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td colspan="3">Create budgets</td>
                        </tr>
                        <tr>
                            <td>Create budgets</td>
                            <td></td>
                            <td></td>
                            <td><span class="tickgreen">✔</span></td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td colspan="3">Track employee time</td>
                        </tr>
                        <tr class="compare-row">
                            <td>Track employee time</td>
                            <td></td>
                            <td></td>
                            <td><span class="tickgreen">✔</span></td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td colspan="3">Stock control</td>
                        </tr>
                        <tr>
                            <td>Stock control</td>
                            <td></td>
                            <td></td>
                            <td><span class="tickgreen">✔</span></td>
                        </tr>
                    </tbody>
                </table>
            </div>

        </section>
    </div>





    <!--<section class="pricing section-padding-100-70" style="background: #edf6fd" id="pricing">

        <div class="container">
            <div class="section-heading text-center">
                <div class="dream-dots justify-content-center fadeInUp" data-wow-delay="0.2s">
                    <span class="gradient-text blue">PRICING PLANS</span>
                </div>
                <h2 class="fadeInUp" data-wow-delay="0.3s">SAS ERP Solution</h2>
                <p class="fadeInUp" data-wow-delay="0.4s">A plan that's right for your business.</p>
            </div>
            <div class="row ">
                <div class="col-lg-4 col-md-6">
                    <div class="pricingTable6 text-center single_price_table_conten wow fadeInUp" data-wow-delay="0.2s" style="visibility: visible; animation-delay: 0.2s; animation-name: fadeInUp;">
                        <h3 class="title">Standard</h3>
                        <div class="price-value">
                            $10.00
                            <span class="month">/month</span>
                        </div>
                        <ul class="pricing-content ">
                            <li>50GB Disk Space</li>
                            <li>50 Email Accounts</li>
                            <li>50GB Monthly Bandwidth</li>
                            <li class="disable"><i class="fa fa-times"></i></li>
                            <li class="disable"><i class="fa fa-times"></i></li>
                        </ul>
                        <a href="#" class="pricingTable-signup">Sign up</a>
                    </div>
                </div>
                <div class="col-lg-4 col-md-6">
                    <div class="pricingTable6 blue single_price_table_conten  text-center wow fadeIn" data-wow-delay="0.3s" style="visibility: visible; animation-delay: 0.3s; animation-name: fadeIn;">

                        <h3 class="title">Business</h3>
                        <div class="price-value">
                            $20.00
                            <span class="month">/month</span>
                        </div>
                        <ul class="pricing-content">
                            <li>60GB Disk Space</li>
                            <li>60 Email Accounts</li>
                            <li>60GB Monthly Bandwidth</li>
                            <li>15 Subdomains</li>
                            <li class="disable"><i class="fa fa-times"></i></li>
                        </ul>
                        <a href="#" class="pricingTable-signup">Sign up</a>
                    </div>
                </div>
                <div class="col-lg-4 col-md-6">
                    <div class="pricingTable6 green ingle_price_table_conten text-center wow fadeInUp" data-wow-delay="0.4s" style="visibility: visible; animation-delay: 0.4s; animation-name: fadeInUp;">

                        <h3 class="title">Premium</h3>
                        <div class="price-value">
                            $30.00
                            <span class="month">/month</span>
                        </div>
                        <ul class="pricing-content">
                            <li>70GB Disk Space</li>
                            <li>70 Email Accounts</li>
                            <li>70GB Monthly Bandwidth</li>
                            <li>20 Subdomains</li>
                            <li>25 Domains</li>
                        </ul>
                        <a href="#" class="pricingTable-signup">Sign up</a>
                    </div>
                </div>
            </div>

            <hr />
            <hr />
            <div class="section-heading text-center">
                <div class="dream-dots justify-content-center fadeInUp" data-wow-delay="0.2s">
                    <span class="gradient-text blue">PRICING PLANS</span>
                </div>
                <h2 class="fadeInUp" data-wow-delay="0.3s">SKY ERP Solution</h2>
                <p class="fadeInUp" data-wow-delay="0.4s">A plan that's right for your business.</p>
            </div>
            <div class="row ">

                <div class="col-lg-4 col-md-6">
                    <div class="pricingTable6 text-center single_price_table_conten wow fadeInUp" data-wow-delay="0.2s" style="visibility: visible; animation-delay: 0.2s; animation-name: fadeInUp;">
                        <h3 class="title">Standard</h3>
                        <div class="price-value">
                            $10.00
                            <span class="month">/month</span>
                        </div>
                        <ul class="pricing-content ">
                            <li>50GB Disk Space</li>
                            <li>50 Email Accounts</li>
                            <li>50GB Monthly Bandwidth</li>
                            <li class="disable"><i class="fa fa-times"></i></li>
                            <li class="disable"><i class="fa fa-times"></i></li>
                        </ul>
                        <a href="#" class="pricingTable-signup">Sign up</a>
                    </div>
                </div>
                <div class="col-lg-4 col-md-6">
                    <div class="pricingTable6 blue single_price_table_conten  text-center wow fadeIn" data-wow-delay="0.3s" style="visibility: visible; animation-delay: 0.3s; animation-name: fadeIn;">

                        <h3 class="title">Business</h3>
                        <div class="price-value">
                            $20.00
                            <span class="month">/month</span>
                        </div>
                        <ul class="pricing-content">
                            <li>60GB Disk Space</li>
                            <li>60 Email Accounts</li>
                            <li>60GB Monthly Bandwidth</li>
                            <li>15 Subdomains</li>
                            <li class="disable"><i class="fa fa-times"></i></li>
                        </ul>
                        <a href="#" class="pricingTable-signup">Sign up</a>
                    </div>
                </div>
                <div class="col-lg-4 col-md-6">
                    <div class="pricingTable6 green ingle_price_table_conten text-center wow fadeInUp" data-wow-delay="0.4s" style="visibility: visible; animation-delay: 0.4s; animation-name: fadeInUp;">

                        <h3 class="title">Premium</h3>
                        <div class="price-value">
                            $30.00
                            <span class="month">/month</span>
                        </div>
                        <ul class="pricing-content">
                            <li>70GB Disk Space</li>
                            <li>70 Email Accounts</li>
                            <li>70GB Monthly Bandwidth</li>
                            <li>20 Subdomains</li>
                            <li>25 Domains</li>
                        </ul>
                        <a href="#" class="pricingTable-signup">Sign up</a>
                    </div>
                </div>
            </div>
            <hr /><hr />
            <div class="section-heading text-center">
                <div class="dream-dots justify-content-center fadeInUp" data-wow-delay="0.2s">
                    <span class="gradient-text blue">PRICING PLANS</span>
                </div>
                <h2 class="fadeInUp" data-wow-delay="0.3s">Zaker Educational Solution</h2>
                <p class="fadeInUp" data-wow-delay="0.4s">A plan that's right for your business.</p>
            </div>
            <div class="row ">

                <div class="col-lg-4 col-md-6">
                    <div class="pricingTable6 text-center single_price_table_conten wow fadeInUp" data-wow-delay="0.2s" style="visibility: visible; animation-delay: 0.2s; animation-name: fadeInUp;">
                        <h3 class="title">Standard</h3>
                        <div class="price-value">
                            $10.00
                            <span class="month">/month</span>
                        </div>
                        <ul class="pricing-content ">
                            <li>50GB Disk Space</li>
                            <li>50 Email Accounts</li>
                            <li>50GB Monthly Bandwidth</li>
                            <li class="disable"><i class="fa fa-times"></i></li>
                            <li class="disable"><i class="fa fa-times"></i></li>
                        </ul>
                        <a href="#" class="pricingTable-signup">Sign up</a>
                    </div>
                </div>
                <div class="col-lg-4 col-md-6">
                    <div class="pricingTable6 blue single_price_table_conten  text-center wow fadeIn" data-wow-delay="0.3s" style="visibility: visible; animation-delay: 0.3s; animation-name: fadeIn;">

                        <h3 class="title">Business</h3>
                        <div class="price-value">
                            $20.00
                            <span class="month">/month</span>
                        </div>
                        <ul class="pricing-content">
                            <li>60GB Disk Space</li>
                            <li>60 Email Accounts</li>
                            <li>60GB Monthly Bandwidth</li>
                            <li>15 Subdomains</li>
                            <li class="disable"><i class="fa fa-times"></i></li>
                        </ul>
                        <a href="#" class="pricingTable-signup">Sign up</a>
                    </div>
                </div>
                <div class="col-lg-4 col-md-6">
                    <div class="pricingTable6 green ingle_price_table_conten text-center wow fadeInUp" data-wow-delay="0.4s" style="visibility: visible; animation-delay: 0.4s; animation-name: fadeInUp;">

                        <h3 class="title">Premium</h3>
                        <div class="price-value">
                            $30.00
                            <span class="month">/month</span>
                        </div>
                        <ul class="pricing-content">
                            <li>70GB Disk Space</li>
                            <li>70 Email Accounts</li>
                            <li>70GB Monthly Bandwidth</li>
                            <li>20 Subdomains</li>
                            <li>25 Domains</li>
                        </ul>
                        <a href="#" class="pricingTable-signup">Sign up</a>
                    </div>
                </div>
            </div>
        </div>

    </section>-->
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