pipeline {
  agent {
    node {
      label 'linux'
    }

  }
  stages {
    stage('docker build') {
      steps {
        echo 'echo docker build'
        sh '''echo "build" 
dotnet publish -c Debug -o ./bin/Debug'''
      }
    }
    stage('test') {
      steps {
        sh '''echo "run server"  
cd "asp_signalR_efcore\\bin\\Debug" 
dotnet asp_signalR_efcore.dll  > server.log &'''
        sleep 3
        sh '''echo "run client" && cd "signalR_client\\bin\\Debug" 
dotnet signalR_client.dll  > client.log  &'''
        input 'check running result'
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