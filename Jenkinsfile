pipeline {
  agent any
  stages {
    stage('build') {
      parallel {
        stage('build') {
          steps {
            echo 'echo build'
            sh '''echo "build project"
dotnet publish -c Debug -o ./bin/Debug'''
          }
        }
        stage('docker build') {
          steps {
            echo 'echo docker build'
          }
        }
      }
    }
    stage('test') {
      steps {
        sh '''echo "run server" 
cd "asp_signalR_efcore\\bin\\Debug"
dotnet asp_signalR_efcore.dll  > server.log &'''
        sleep 3
        sh '''echo "run client"
cd "signalR_client\\bin\\Debug"
dotnet signalR_client.dll  > client.log &'''
        input 'check input'
      }
    }
    stage('deploy') {
      steps {
        sh 'echo "deploy"'
        archiveArtifacts(artifacts: '**/bin/Debug/*.*', onlyIfSuccessful: true)
      }
    }
  }
}