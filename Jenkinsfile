    
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
			defaultValue:'anoop2677')
        password(
            name:'DOCKER_PASSWORD',
			defaultValue:'0@noopkum@r')
        string(
            name: 'BUILD_VERSION',
            defaultValue: '1.0')
        string(
            name: 'REPOSITORY',
            defaultValue: 'webAPI')
        
    }
    stages {
        stage('Build') {
            when {
                expression {params.CHOSEN_ACTION == 'BUILD' || params.CHOSEN_ACTION == 'TEST' || params.CHOSEN_ACTION == 'PUBLISH'}
            }
            steps {
                bat script: '''dotnet %NETCORE_VERSION% restore  %SOLUTION_NAME% --source https://api.nuget.org/v3/index.json
                dotnet %NETCORE_VERSION% build  %SOLUTION_NAME% -p:CONFIGURATION=release -V:n'''
            }
        }
        stage('Test') {
            when {
                expression {params.CHOSEN_ACTION == 'TEST' || params.CHOSEN_ACTION == 'PUBLISH'}
            }
            steps {
                bat script: '''dotnet %NETCORE_VERSION% test  %TEST_PROJECT_PATH%'''
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
		docker build --tag=firsttag .
                docker login -u rupawar -p adminadmin
                docker push tag firsttag rupawar/firstrepo-1.0
                docker push rupawar/firstrepo-1.0
		docker run --name firstrepo-1.0 -p 5000:5505 firsttag
                '''
			}				 
        } 
    }
    post {
            always {
		    bat script:'''
		    docker logout
		    '''
                deleteDir()
            }
        }
}
