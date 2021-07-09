"""
The template of the main script of the machine learning process
"""
import random


class MLPlay:
    def __init__(self):
        """
        Constructor
        """
        self.ball_served = False
        self.previous_ball = (0, 0)

    def update(self, scene_info):
        """
        Generate the command according to the received `scene_info`.
        """

        # Make the caller to invoke `reset()` for the next round.
        if scene_info["status"] == "GAME_OVER" or scene_info["status"] == "GAME_PASS":
            return "RESET"

        if not self.ball_served:
            command = "SERVE_TO_LEFT"
        else:
            g8bricks = []
            platform = scene_info["platform"][0]
            ball_x = scene_info["ball"][0]
            ball_y = scene_info["ball"][1]
            ball_speed_x = scene_info["ball"][0] - self.previous_ball[0]
            ball_speed_y = scene_info["ball"][1] - self.previous_ball[1]
            for i in scene_info["bricks"]:
                if i[1] >= 290:
                    g8bricks.append(i)
            slope = ball_speed_y / ball_speed_x if ball_speed_x != 0 else 0
            px = ball_x + (395 - ball_y) / slope if slope != 0 else ball_x
            if ball_speed_y > 0:
                bounce = False
                if ball_speed_x > 0:
                    for x in [50, 25]:
                        yy = abs((ball_x - x)*slope) + ball_y
                        for b in g8bricks:
                            if b[0]+25 == x and b[1] - 5 <= yy <= b[1] + 10:
                                px += 2*(x - px)
                                bounce = True
                                break
                        if bounce:
                            break
                else:
                    for x in [150, 175]:
                        yy = abs((ball_x+5 - x)*slope) + ball_y
                        for b in g8bricks:
                            if b[0] == x and b[1] - 5 <= yy <= b[1] + 10:
                                px -= 2*(x - px)
                                bounce = True
                                break
                        if bounce:
                            break
            if 20 <= px <= 175:
                px -= 20
            elif 0 <= px <= 20:
                px = 0
            elif 180 <= px <= 195:
                px = 160
            else:
                while px < 0 or px > 195:
                    if px < 0:
                        px *= -1
                    elif px > 195:
                        px = 195 - (px - 195)
                if 20 <= px <= 180:
                    px -= 20
                elif 0 <= px <= 20:
                    px = 0
                elif 180 <= px <= 195:
                    px = 160
            if ball_speed_y < 0:
                px = 80
            if ball_speed_y < 0:
                if ball_y >= 290:
                    b = False
                    for i in g8bricks:
                        xx = ((i[1] + 10) - ball_y)/slope + ball_x if slope != 0 else ball_x
                        if i[0] - 5 < xx < i[0] + 25:
                            px -= 2*(px - xx)
                            b = True
                            break
                    if not b:
                        px = 80
                else:
                    px = 80

            if ball_y < 280:
                px = 80

            if px - random.randint(0, 5) <= platform <= px + random.randint(0, 5):
                command = "NONE"
            else:
                command = "MOVE_RIGHT" if platform < px else "MOVE_LEFT"
            self.previous_ball = scene_info["ball"]

        return command

    def reset(self):
        """
        Reset the status
        """
        self.ball_served = False
        self.previous_ball = (0, 0)
