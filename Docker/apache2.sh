service apache2 start
a2ensite web-site.conf
a2dissite 000-default.conf
a2enmod proxy proxy_http proxy_html
service apache2 restart
