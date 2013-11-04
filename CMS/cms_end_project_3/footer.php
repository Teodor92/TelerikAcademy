<div class="5grid-layout 5grid">
    <div class="row" id="footer-content">
        <div class="6u" id="box1">
            <section>
                <?php get_sidebar('bottom-left') ?>
            </section>
        </div>
        <div class="3u" id="box2">
            <section>
                <?php get_sidebar('bottom-center') ?>
            </section>
        </div>
        <div class="3u" id="box3">
            <section>
                <?php get_sidebar('bottom-right') ?>
            </section>
        </div>
    </div>
</div>
<div id="copyright" class="5grid-layout 5grid">
    <section>
        <?php
        if (get_option('ccp_footer_text') != '') {
            echo(stripslashes(get_option('ccp_footer_text')));
        }
        ?>
    </section>
</div>
<div id="social" class="5grid-layout 5grid">
    <section>
        <?php
        if (get_option('ccp_facebookid') != '') {
            ?>
            <a href="<?php echo get_option('ccp_facebookid'); ?>" target="_blank">
                <img src="<?php echo get_template_directory_uri() ?>/images/social/facebook-icon.png" title="Facebook Page" width="" height="" />
            </a>
            <?php
        }
        ?>
        <?php
        if (get_option('ccp_twitterid') != '') {
            ?>
            <a href="<?php echo get_option('ccp_twitterid'); ?>" target="_blank">
                <img src="<?php echo get_template_directory_uri() ?>/images/social/twitter-icon.png" title="Twitter Page" width="" height="" />
            </a>
            <?php
        }
        ?>
        <?php
        if (get_option('ccp_googleplusid') != '') {
            ?>
            <a href="<?php echo get_option('ccp_googleplusid'); ?>" target="_blank">
                <img src="<?php echo get_template_directory_uri() ?>/images/social/google-icon.png" title="Google+ Page" width="" height="" />
            </a>
            <?php
        }
        ?>
    </section>
</div>
<?php wp_footer() ?> 
</body>
</html>
