    
pipeline {
    agent any
    parameters {
        choice(
            choices: ['BUILD', 'TEST', 'PUBLISH'],
            name: 'CHOSEN_ACTION')
        string(
            name: 'GIT_PATH',
            defaultValue: 'https://github.com/tavisca-rpawar/WebAPI01.git')
        string(
            name: 'SOLUTION_NAME',
            defaultValue: 'WebApplication1.sln')
        string(
            name: 'TEST_PROJECT_PATH',
            defaultValue: 'BasicWebApiTest/BasicWebApiTest.csproj')
        string (
            name: 'PROJECT_PUBLISH_PATH',
            defaultValue: 'WebApplication1/WebApplication1.csproj')
        string(
            name: 'NETCORE_VERSION',
            defaultValue: '')
        string(
            name:'DOCKER_USER_ID',
	    defaultValue:'rupawar')
        password(
            name:'DOCKER_PASSWORD',
	    defaultValue:'adminadmin')
        string(
            name: 'BUILD_VERSION',
            defaultValue: '1.0')
        string(
            name: 'REPOSITORY',
            defaultValue: 'firstrepo-1.0')
	string(
            name: 'HOST_PORT',
            defaultValue: '5000')
	string(
            name: 'CONTAINER_PORT',
            defaultValue: '80')
        
    }
    stages {
        stage('Build') {
            when {
                expression {params.CHOSEN_ACTION == 'BUILD' || params.CHOSEN_ACTION == 'TEST' || params.CHOSEN_ACTION == 'PUBLISH'}
            }
            steps {
                bat script: '''
		dotnet C:/sonar/SonarScanner.MSBuild.dll begin /k:"WebApi" /d:sonar.host.url="http://localhost:9000" /d:sonar.login="4d3652d0c2c6cad8764005b374b37562ef06df79"
		dotnet %NETCORE_VERSION% restore %SOLUTION_NAME%
                dotnet %NETCORE_VERSION% build %SOLUTION_NAME% -p:CONFIGURATION=release -V:q'''
            }
        }
        stage('Test') {
            when {
                expression {params.CHOSEN_ACTION == 'TEST' || params.CHOSEN_ACTION == 'PUBLISH'}
            }
            steps {
                bat script: '''
			dotnet %NETCORE_VERSION% test  %TEST_PROJECT_PATH%
			dotnet C:/sonar/SonarScanner.MSBuild.dll end /d:sonar.login="4d3652d0c2c6cad8764005b374b37562ef06df79"
		'''
            }
        }
        stage('Publish') {
            when {
                expression {params.CHOSEN_ACTION == 'PUBLISH'}
            }
            steps {
                bat script: '''dotnet %NETCORE_VERSION% publish '''
            }
        }
        stage('Deploy') {
            when {
                expression {params.CHOSEN_ACTION == 'PUBLISH'}
            }
            steps{	
                bat script: '''
		docker build . -t %DOCKER_USER_ID%/%REPOSITORY%
                docker login -u %DOCKER_USER_ID% -p %DOCKER_PASSWORD%
                docker push %DOCKER_USER_ID%/%REPOSITORY%
		
                '''
			}				 
        } 
    }
   post {
            always {
		    bat script:'''
		    docker logout
		    '''
                
            }
        }
}
