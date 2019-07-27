pipeline {
  agent any
  stages {
    stage('build') {
      parallel {
        stage('build') {
          steps {
            echo 'echo build'
            bat 'dotnet publish -c Debug -o ./bin/Debug'
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
        bat 'echo "run server"  cd "asp_signalR_efcore\\bin\\Debug" dotnet asp_signalR_efcore.dll  > server.log &'
        sleep 3
        bat 'echo "run client" cd "signalR_client\\bin\\Debug" dotnet signalR_client.dll  > client.log &'
        input 'check result'
      }
    }
    stage('deploy') {
      steps {
        archiveArtifacts(artifacts: '**/bin/Debug/*.*', onlyIfSuccessful: true)
        echo 'echo "deploy"'
      }
    }
  }
}