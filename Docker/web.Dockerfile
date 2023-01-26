FROM ubuntu/apache2
COPY ["./web-site.conf", "/etc/apache2/sites-available/web-site.conf"]
COPY apache2.sh /root/
RUN bash /root/apache2.sh
RUN rm /root/apache2.sh
RUN /etc/init.d/apache2 restart
RUN apt update
RUN apt install -y dotnet-sdk-6.0
WORKDIR /app
RUN apt-get install -y supervisor

COPY ["./supervisord.conf", "/etc/supervisor/conf.d/supervisord.conf"]

ENTRYPOINT ["/bin/bash","-c","service supervisor start && apache2-foreground"]
