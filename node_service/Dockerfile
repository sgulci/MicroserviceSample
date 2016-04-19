FROM node:argon

ADD . /app/

WORKDIR /app

RUN npm install

EXPOSE 3000

CMD ["node", "/app/connect_mock_test.js"]
