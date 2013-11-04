<?php get_header() ?>
<div class="5grid-layout 5grid">
    <div class="row">
        <div class="6u">
            <!-- Displaying short versions oof the posts -->
            <div id="content">
                <?php
                $temp = $wp_query;
                $wp_query = null;
                $wp_query = new WP_Query();
                $wp_query->query('showposts=5' . '&paged=' . $paged);

                if ($wp_query->have_posts()):
                    ?>
                    <div id="content">
                        <?php
                        while ($wp_query->have_posts()):

                            the_post()
                            ?>

                            <section>
                                <div class="post">
                                    <h2>
                                        <a href="<?php the_permalink() ?>"><?php the_title() ?></a>
                                    </h2>
                                    <p>
                                        <a href="<?php the_permalink() ?>">
                                            <?php if (has_post_thumbnail()) { ?>
                                                <?php the_post_thumbnail(); ?>
                                            <?php } ?>
                                        </a>

                                        <?php the_excerpt() ?>

                                    <div class="tag-category">
                                        Category:
                                        <?php
                                        the_category(', ');
                                        ?>
                                        <?php
                                        the_tags();
                                        ?>
                                    </div>

                                    <p class="button-style">
                                        <a href="<?php the_permalink(); ?>">Read Full Article</a>
                                    </p>
                                </div>
                            </section>

                            <?php
                        endwhile;

                        if ($paged > 1) {
                            ?>

                            <nav id="nav-posts">
                                <div class="prev"><?php next_posts_link('&laquo; Previous Posts'); ?></div>
                                <div class="next"><?php previous_posts_link('Newer Posts &raquo;'); ?></div>
                            </nav>

                        <?php } else { ?>

                            <nav id="nav-posts">
                                <div class="prev"><?php next_posts_link('&laquo; Previous Posts'); ?></div>
                            </nav>

                        <?php } ?>

                        <?php
                        wp_reset_postdata();
                        ?>
                    </div>
                    <?php
                endif;
                ?>

            </div>
        </div>
        <!-- sidebar TODO: Make it dynamic -->
        <div class="3u" id="sidebar1">
            <!-- Inner sidebar -->
            <section>
                <?php get_sidebar('sidebar-one') ?>
            </section>
            <section>
                <?php get_sidebar('inner-second') ?>
            </section>
        </div>
        <div class="3u">
            <div id="sidebar2">
                <div class="sbox1">
                    <?php get_sidebar('main') ?>
                </div>
                <div class="sbox2">
                    <?php get_sidebar('main-second') ?>
                </div>
            </div>
        </div>
    </div>
</div>
</div>
</div>
<?php get_footer() ?>