FROM mono:onbuild

EXPOSE 5000

CMD ["mono", "./ServiceRegistery/ServiceRegistery.exe"]