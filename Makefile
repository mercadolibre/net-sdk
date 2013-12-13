test:
	cd mockapi ; npm install
	node mockapi/app.js &
	xbuild
	nunit-console SDKTest/bin/Debug/SDKTest.dll
	kill `cat /tmp/mockapi.pid` 
	
.PHONY: test
