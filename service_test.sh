curl -s http://docker-machine:5000/api/registery/save/info=3001,nodeapp1 | python -m json.tool
curl -s http://docker-machine:5000/api/registery/save/info=3002,nodeapp2 | python -m json.tool
curl -s http://docker-machine:5000/api/registery/save/info=3003,nodeapp3 | python -m json.tool

curl -s http://docker-machine:5000/api/registery/save/info=3006,postgres1 | python -m json.tool
curl -s http://docker-machine:5000/api/registery/save/info=3007,postgres2 | python -m json.tool

curl -s http://docker-machine:5000/api/registery/save/info=3008,mongo1 | python -m json.tool
curl -s http://docker-machine:5000/api/registery/save/info=3009,mongo2 | python -m json.tool

curl -s http://docker-machine:5000/api/registery/getserviceinfo/nodeapp1 | python -m json.tool
curl -s http://docker-machine:5000/api/registery/getserviceinfo/nodeapp2 | python -m json.tool
curl -s http://docker-machine:5000/api/registery/getserviceinfo/nodeapp3 | python -m json.tool

curl -s http://docker-machine:5000/api/registery/getserviceinfo/postgres1 | python -m json.tool
curl -s http://docker-machine:5000/api/registery/getserviceinfo/postgres2 | python -m json.tool

curl -s http://docker-machine:5000/api/registery/getserviceinfo/mongo1 | python -m json.tool
curl -s http://docker-machine:5000/api/registery/getserviceinfo/mongo2 | python -m json.tool
