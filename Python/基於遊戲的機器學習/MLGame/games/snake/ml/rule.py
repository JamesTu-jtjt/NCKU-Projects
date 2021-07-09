"""
The template of the script for playing the game in the ml mode
"""

class MLPlay:
    def __init__(self):
        """
        Constructor
        """
        self.state = 'DOWN'
        self.loop = False
        pass

    def update(self, scene_info):
        """
        Generate the command according to the received scene information
        """
        if scene_info["status"] == "GAME_OVER":
            # print(scene_info["snake_head"], scene_info["food"], self.state)
            return "RESET"

        command = self.state
        snake_head = scene_info["snake_head"]
        food = scene_info["food"]
        snake_body = scene_info["snake_body"]
        length = len(snake_body)
        if length > 55 and self.state == "LEFT":
            self.loop = True

        if self.loop:
            reloop = True if food[0] < snake_body[length - 1][0] else False
            for i in range(length):
                if snake_body[i][1] == 0:
                    reloop = False
                    break
            if self.state == 'DOWN':
                if snake_head[1] == 290:
                    command = "RIGHT"
            elif self.state == 'UP':
                if reloop:
                    if snake_head[1] == 0:
                        command = "LEFT"
                elif snake_head[0] == 290:
                    if snake_head[1] == 0:
                        command = "LEFT"
                else:
                    if snake_head[1] == 10:
                        command = "RIGHT"
            elif self.state == "RIGHT":
                if snake_head[1] == 10:
                    command = "DOWN"
                else:
                    command = "UP"
            elif self.state == "LEFT":
                if snake_body[length - 1][0] > food[0]:
                    d = food[0] if food[0] % 20 == 0 else food[0] - 10
                else:
                    d = food[0] - 20 if food[0] % 20 == 0 else food[0] - 10
                if d < 0 or snake_head[0] < d:
                    d = 0
                if snake_head[0] == d:
                    command = "DOWN"
        else:
            if self.state == 'DOWN':
                if snake_head[1] == 290:
                    command = "RIGHT"
            elif self.state == 'UP':
                if snake_head[1] == 0:
                    command = "LEFT"
            elif self.state == "RIGHT":
                if snake_head[0] == 290:
                    command = "UP"
            elif self.state == "LEFT":
                if food[0] > snake_head[0]:
                    command = "DOWN"
                elif snake_head[0] == food[0]:
                    command = "DOWN"
                elif snake_head[0] == 0:
                    command = "DOWN"
        if length > 100:
            command = "LEFT" if self.state == "UP" or self.state == "DOWN" else "UP"

        self.state = command
        return command

    def reset(self):
        """
        Reset the status if needed
        """
        self.state = 'DOWN'
        self.loop = False
        pass
